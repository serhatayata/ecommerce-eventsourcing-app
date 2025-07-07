using Common.Infrastructure.DbContexts;
using Inventory.Domain.Models.Equipments;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Inventory.Infrastructure.Persistence;

public class InventoryDbContext : BaseDbContext<InventoryDbContext>
{
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<EquipmentImage> EquipmentImages { get; set; }

    public InventoryDbContext(
    DbContextOptions<InventoryDbContext> options,
    IPublisher publisher)
        : base(options, publisher)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("inventory");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
