using Common.Domain.Events;

namespace Common.Domain.Entities;

public abstract class Entity<TId> : IEntity
{
    private readonly ICollection<IDomainEvent> events;

    protected Entity() => events = new List<IDomainEvent>();

    public TId Id { get; protected set; } = default!;

    public IReadOnlyCollection<IDomainEvent> Events
        => events.ToList().AsReadOnly();

    public void ClearEvents() => events.Clear();

    protected void AddEvent(IDomainEvent domainEvent)
        => events.Add(domainEvent);

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        if (Id?.Equals(default(TId)) == true || other.Id?.Equals(default(TId)) == true) return false;
        return Id?.Equals(other.Id) == true;
    }

    public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
    {
        if (first is null && second is null) return true;
        if (first is null || second is null) return false;
        return first.Equals(second);
    }

    public static bool operator !=(Entity<TId>? first, Entity<TId>? second) => !(first == second);

    public override int GetHashCode() => (GetType().ToString() + Id?.ToString()).GetHashCode();
}


public abstract class Entity : Entity<int>
{
}