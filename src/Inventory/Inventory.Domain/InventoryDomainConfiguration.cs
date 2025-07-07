using System.Reflection;
using Common.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Domain;

public static class InventoryDomainConfiguration
{
    public static IServiceCollection AddInventoryDomain(
    this IServiceCollection services)
        => services.AddInitialData(Assembly.GetExecutingAssembly());  
    
    private static IServiceCollection AddInitialData(
    this IServiceCollection services,
    Assembly assembly)
        => services
            .Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IInitialData)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
}