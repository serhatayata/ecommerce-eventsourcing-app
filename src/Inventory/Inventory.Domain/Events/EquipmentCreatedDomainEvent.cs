using System.Text.Json.Serialization;
using Common.Domain.Events;
using MediatR;

namespace Inventory.Domain.Events;

public sealed record EquipmentCreatedDomainEvent : DomainEvent, INotification
{
    [JsonConstructor]
    public EquipmentCreatedDomainEvent() { }

    public EquipmentCreatedDomainEvent(
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