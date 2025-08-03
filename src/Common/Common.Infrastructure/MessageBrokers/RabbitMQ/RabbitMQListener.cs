using Common.Domain.Core.Events;
using Common.Domain.MessageBrokers;

namespace Common.Infrastructure.MessageBrokers.RabbitMQ;

using MassTransit;

public class RabbitMQListener : IEventListener
{
    private readonly IBus _bus;

    public RabbitMQListener(IBus bus)
    {
        _bus = bus;
    }

    public async Task Publish<TEvent>(TEvent @event)
    where TEvent : IEvent
    {
        await _bus.Publish(@event);
    }

    public async Task Publish(string message, string type)
    {
        await _bus.Publish(new { Message = message, Type = type });
    }
}