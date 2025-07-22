using Common.Domain.EventStores.Aggregates;

namespace Common.Domain.EventStores.Repositories;

public interface IRepository<TAggregate, R> where TAggregate : IAggregate<R>
{
    Task<TAggregate> Find(R id);
    Task<ICollection<TAggregate>> Find(ICollection<R> id);
    Task Add(TAggregate aggregate);
    Task Add(ICollection<TAggregate> aggregates);
    Task Update(TAggregate aggregate);
    Task Update(ICollection<TAggregate> aggregates);
    Task Delete(TAggregate aggregate);
    Task Delete(ICollection<TAggregate> aggregates);
}