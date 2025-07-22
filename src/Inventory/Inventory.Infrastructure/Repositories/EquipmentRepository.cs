using Common.Infrastructure.Repositories;
using Inventory.Domain.Models.Equipments;
using Inventory.Infrastructure.Persistence;

namespace Inventory.Infrastructure.Repositories;

public class EquipmentRepository : EfRepository<Equipment, InventoryDbContext, Guid>
{
    private readonly InventoryDbContext _dbContext;

    public EquipmentRepository(
    InventoryDbContext dbContext)
    : base(dbContext)
    {
        _dbContext = dbContext;
    }
}