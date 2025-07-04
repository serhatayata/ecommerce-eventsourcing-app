using Common.Domain.Events;

namespace Common.Domain.Entities;

public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> Events { get; }
    void ClearEvents();
}