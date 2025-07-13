using Common.Domain.Core.Events;

namespace Common.Domain.Outbox;

public interface IOutboxListener
{
    Task Commit(OutboxMessage message);
    Task Commit<TEvent>(TEvent @event) where TEvent : IEvent;
}