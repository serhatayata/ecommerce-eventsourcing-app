using Common.Domain.Events;

namespace Common.Infrastructure.EventStores.Projections;

    public interface IProjection
    {
        Type[] Handles { get; }
        void Handle(IEvent @event);
    }