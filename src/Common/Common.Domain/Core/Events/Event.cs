namespace Common.Domain.Core.Events;

public abstract record Event : IEvent
{
    public virtual Guid Id { get; } = Guid.NewGuid();
    public virtual DateTime CreatedUtc { get; } = DateTime.UtcNow;
}