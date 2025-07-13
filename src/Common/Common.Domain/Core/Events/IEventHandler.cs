using MediatR;

namespace Common.Domain.Core.Events;

public interface IEventHandler<T> : INotificationHandler<T> where T : IEvent
{ }