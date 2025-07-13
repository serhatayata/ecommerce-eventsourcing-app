using Common.Domain.Core.Events;

namespace Common.Domain.EventStores.Aggregates;

public interface IAggregate
{
    Guid Id { get; }
    int Version { get; }
    DateTime CreatedUtc { get; }

    IEnumerable<IEvent> DequeueUncommittedEvents();

}