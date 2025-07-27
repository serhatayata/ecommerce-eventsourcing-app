namespace Inventory.Application.Commands.Create;

public class CreateEquipmentResponse
{
    public Guid Id { get; set; }
    public Guid OwnerUserId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal PricePerDay { get; init; }
    public string Currency { get; init; }
    public bool IsAvailable { get; init; }
    public IReadOnlyCollection<string> Images { get; init; }
}