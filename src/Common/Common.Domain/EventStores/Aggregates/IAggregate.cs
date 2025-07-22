using Common.Domain.Core.Events;

namespace Common.Domain.EventStores.Aggregates;

public interface IAggregate<T>
{
    T Id { get; }
    int Version { get; }
    DateTime CreatedUtc { get; }

    IEnumerable<IEvent> DequeueUncommittedEvents();
}

public interface IAggregate : IAggregate<Guid>
{
}