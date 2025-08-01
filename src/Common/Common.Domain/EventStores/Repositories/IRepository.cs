using Common.Domain.EventStores.Aggregates;

namespace Common.Domain.EventStores.Repositories;

public interface IRepository<TAggregate> 
where TAggregate : IAggregate<Guid>
{
    Task<TAggregate> Find(Guid id);
    Task<ICollection<TAggregate>> Find(ICollection<Guid> id);
    Task Add(TAggregate aggregate);
    Task Add(ICollection<TAggregate> aggregates);
    Task Update(TAggregate aggregate);
    Task Update(ICollection<TAggregate> aggregates);
    Task Delete(TAggregate aggregate);
    Task Delete(ICollection<TAggregate> aggregates);
}