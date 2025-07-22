using Common.Domain.Core.Events;
using Inventory.Domain.Models.Equipments;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Inventory.Infrastructure.Persistence;

public class InventoryDbContext : DbContext
{
    private readonly IEventBus _eventBus;

    public InventoryDbContext(
    DbContextOptions<InventoryDbContext> options,
    IEventBus eventBus)
        : base(options)
    {
        _eventBus = eventBus;
    }

    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<EquipmentImage> EquipmentImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("inventory");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public async Task SaveChangesAndCommit(IEvent @event)
    {
        await using var transaction = await Database.BeginTransactionAsync();
        await SaveChangesAsync();
        await _eventBus.Commit(@event);
        await transaction.CommitAsync();
    }
}
