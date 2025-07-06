using Common.Domain.Entities;

namespace Inventory.Domain.Models.Equipments;

public class EquipmentImage : Entity
{
    public string Url { get; private set; }

    public EquipmentImage(string url)
    {
        Url = url;
    }
}