using Common.Domain.Core.Events;
using Common.Domain.MessageBrokers;

namespace Common.Infrastructure.MessageBrokers.RabbitMQ;

using MassTransit;

public class RabbitMQListener : IEventListener
{
    private readonly IPublishEndpoint _publishEndpoint;

    public RabbitMQListener(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        await _publishEndpoint.Publish(@event);
    }

    public async Task Publish(string message, string type)
    {
        await _publishEndpoint.Publish(new { Message = message, Type = type });
    }
}