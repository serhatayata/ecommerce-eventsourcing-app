using System.Text.Json.Serialization;
using Common.Domain.Core.Events;

namespace Inventory.Domain.Events;

public sealed record EquipmentCreatedEvent : Event
{
    [JsonConstructor]
    public EquipmentCreatedEvent() { }

    public EquipmentCreatedEvent(
    Guid ownerUserId,
    string name,
    decimal pricePerDay)
    {
        OwnerUserId = ownerUserId;
        Name = name;
        PricePerDay = pricePerDay;
    }

    public Guid OwnerUserId { get; init; }
    public string Name { get; init; }
    public decimal PricePerDay { get; set; }
}