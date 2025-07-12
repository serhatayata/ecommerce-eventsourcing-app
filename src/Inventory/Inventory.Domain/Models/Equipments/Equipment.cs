using Common.Domain.Aggregates;
using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Inventory.Domain.Events;

namespace Inventory.Domain.Models.Equipments;

public class Equipment : Entity<Guid>, IAggregateRoot
{
    public Guid OwnerUserId { get; private set; }
    public EquipmentDetails Details { get; private set; }
    public Money PricePerDay { get; private set; }
    public bool IsAvailable { get; private set; }

        private readonly List<EquipmentImage> _images = new();
    public IReadOnlyCollection<EquipmentImage> Images => _images;

    private Equipment() { } // ORM için

    private Equipment(Guid ownerUserId, EquipmentDetails details, Money pricePerDay)
    {
        OwnerUserId = ownerUserId;
        Details = details;
        PricePerDay = pricePerDay;
        IsAvailable = true;
    }

    public static Equipment Create(Guid ownerUserId, string name, string description, decimal price, string currency)
    {
        var details = new EquipmentDetails(name, description);
        var money = Money.Create(price, currency);
        var equipment = new Equipment(ownerUserId, details, money);
        equipment.RaiseEquipmentCreatedDomainEvent();
        return equipment;
    }

    public void AddImage(string url)
    {
        _images.Add(new EquipmentImage(url));
    }

    private void RaiseEquipmentCreatedDomainEvent()
        => AddEvent(new EquipmentCreatedDomainEvent(
            OwnerUserId,
            Details.Name,
            PricePerDay.Amount
        ));

    public void MarkAsUnavailable() => IsAvailable = false;
    public void MarkAsAvailable() => IsAvailable = true;
}