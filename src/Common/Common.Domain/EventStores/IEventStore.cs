using Common.Domain.Core.Events;
using Common.Domain.EventStores.Aggregates;
using Common.Domain.EventStores.Projections;
using Common.Domain.EventStores.Snapshots;

namespace Common.Domain.EventStores;

public interface IEventStore
{
    void AddSnapshot(ISnapshot snapshot);

    void AddProjection(IProjection projection);

    Task AppendEvent<TAggregate>(Guid aggregateId, IEvent @event, int? expectedVersion = null, Func<StreamState, Task> action = null) where TAggregate : IAggregate<Guid>;

    Task<TAggregate> AggregateStream<TAggregate>(Guid aggregateId, int? version = null, DateTime? createdUtc = null) where TAggregate : IAggregate<Guid>;
    Task<ICollection<TAggregate>> AggregateStream<TAggregate>(ICollection<Guid> ids) where TAggregate : IAggregate<Guid>;

    Task<IEnumerable<StreamState>> GetEvents(Guid aggregateId, int? version = null, DateTime? createdUtc = null);

    Task Store<TAggregate>(TAggregate aggregate, Func<StreamState, Task> action = null) where TAggregate : IAggregate<Guid>;
    Task Store<TAggregate>(ICollection<TAggregate> aggregates, Func<StreamState, Task> action = null) where TAggregate : IAggregate<Guid>;
}