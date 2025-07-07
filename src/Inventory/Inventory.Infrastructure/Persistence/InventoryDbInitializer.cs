using Common.Infrastructure.Persistence;
using Inventory.Domain.Models.Equipments;

namespace Inventory.Infrastructure.Persistence;

public class InventoryDbInitializer : DbInitializer
{
    private readonly InventoryDbContext _dbContext;

    public InventoryDbInitializer(
    InventoryDbContext dbContext)
    : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override void Initialize()
    {
        base.Initialize();

        InitializeEquipments();
    }

    public void InitializeEquipments()
    {
        if (_dbContext.Equipments.Any()) return;

        var equipments = new List<Equipment>
        {
            Equipment.Create(Guid.NewGuid(), "Excavator", "Heavy machinery for digging", 1000, "USD"),
            Equipment.Create(Guid.NewGuid(), "Forklift", "Material handling equipment", 500, "USD"),
            Equipment.Create(Guid.NewGuid(), "Bulldozer", "Powerful tracked vehicle", 1500, "USD"),
        };

        // Seed images for each equipment
        equipments[0].AddImage("/images/excavator.jpg");
        equipments[1].AddImage("/images/forklift.jpg");
        equipments[2].AddImage("/images/bulldozer.jpg");

        _dbContext.Equipments.AddRange(equipments);
        _dbContext.SaveChanges();
    }
}