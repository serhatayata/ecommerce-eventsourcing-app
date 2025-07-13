using Common.Domain.Core.Events;

namespace Common.Domain.EventStores.Projections;

public interface IProjection
{
    Type[] Handles { get; }
    void Handle(IEvent @event);
}