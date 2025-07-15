using Common.Domain.EventStores;

namespace Common.Infrastructure.EventStores.Stores;

public interface IStore
{
    Task Add(StreamState stream);
    Task<IEnumerable<StreamState>> GetEvents(Guid aggregateId, int? version = null, DateTime? createdUtc = null);
}