using System.Reflection;
using Common.Domain.EventStores.Repositories;
using Common.Infrastructure.EventStores;
using Common.Infrastructure.MessageBrokers;
using Common.Infrastructure.Persistence;
using Common.Infrastructure.ServiceDiscovery.Consul;
using Inventory.Domain.Contracts;
using Inventory.Domain.Models;
using Inventory.Domain.Models.Equipments;
using Inventory.Infrastructure.Persistence;
using Inventory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Infrastructure;

public static class InventoryInfrastructureConfiguration
{
    public static IServiceCollection AddInventoryInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        services
            .AddDatabase(configuration)
            .AddRepositories()
            .AddServiceDiscovery(configuration)
            .AddMessageBroker(configuration)
            .AddOutbox(configuration, options => options.UseSqlServer(configuration.GetConnectionString(ConnectionStringKeys.OutboxConnection)))
            .AddEventStore<Equipment>(configuration, options => options.UseSqlServer(configuration.GetConnectionString("EventStoreConnection")))
            .AddTransient<IDbInitializer, InventoryDbInitializer>()
            .AddTransient<IEquipmentRepository, EquipmentRepository>();

        return services;
    }

    private static IServiceCollection AddDatabase(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        services
            .AddScoped<DbContext, InventoryDbContext>()
            .AddDbContext<InventoryDbContext>(options => options
                .UseSqlServer(
                    configuration.GetConnectionString(ConnectionStringKeys.DefaultConnection),
                    sqlOptions => sqlOptions
                        .MigrationsHistoryTable("__EFMigrationsHistory", "inventory")
                        .EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null)
                        .MigrationsAssembly(
                            typeof(InventoryDbContext).Assembly.FullName)));

        return services;
    }

    private static IServiceCollection AddRepositories(
    this IServiceCollection services)
    {
        services
            .Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IRepository<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return services;
    }

    private static IServiceCollection AddServiceDiscovery(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        services.AddConsul(configuration);

        return services;
    }
}