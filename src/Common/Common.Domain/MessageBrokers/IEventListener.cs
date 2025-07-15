using Common.Domain.Core.Events;

namespace Common.Domain.MessageBrokers;

public interface IEventListener
{
    Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    Task Publish(string message, string type);
}