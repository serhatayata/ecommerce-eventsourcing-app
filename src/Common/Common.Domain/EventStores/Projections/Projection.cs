using Common.Domain.Core.Events;

namespace Common.Domain.EventStores.Projections;

public abstract class Projection : IProjection
{
    private readonly Dictionary<Type, Action<IEvent>> Handlers = new Dictionary<Type, Action<IEvent>>();

    public Type[] Handles => Handlers.Keys.ToArray();

    protected virtual void Projects<TEvent>(Action<IEvent> action)
    {
        Handlers.Add(typeof(IEvent), @event => action(@event));
    }

    public virtual void Handle(IEvent @event)
    {
        Handlers[@event.GetType()](@event);
    }
}