namespace Common.Domain.ValueObjects;

public class EquipmentDetails : ValueObject
{
    public string Name { get; }
    public string Description { get; }

    public EquipmentDetails(
    string name,
    string description)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? string.Empty;
    }
}