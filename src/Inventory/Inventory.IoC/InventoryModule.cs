using Inventory.Domain;
using Inventory.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.IoC;

public static class InventoryModule
{
    public static void Register(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        services
        // .AddInventoryApplication(configuration)
        .AddInventoryInfrastructure(configuration)
        .AddInventoryDomain();
    }
}