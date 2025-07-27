
using Common.Domain.Core.Events;

namespace Common.Domain.Entities;

public interface IEntity
{
    IReadOnlyCollection<IEvent> Events { get; }
    void ClearEvents();
}