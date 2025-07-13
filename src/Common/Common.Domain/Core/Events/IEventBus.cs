using Common.Domain.EventStores;

namespace Common.Domain.Core.Events;

public interface IEventBus
{
    Task PublishLocal(params IEvent[] events);
    Task Commit(params IEvent[] events);
    Task Commit(StreamState stream);
}