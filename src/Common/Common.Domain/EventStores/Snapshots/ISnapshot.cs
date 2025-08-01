using Common.Domain.EventStores.Aggregates;

namespace Common.Domain.EventStores.Snapshots;

public interface ISnapshot
{
    Type Handles { get; }
    void Handle(IAggregate<Guid> aggregate);
}