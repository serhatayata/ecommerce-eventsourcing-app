using System.Linq.Expressions;
using Common.Domain.EventStores.Aggregates;

namespace Common.Domain.Repositories;

public interface IEfRepository<T, R>
where T : IAggregate<R>
{
    Task<int> SaveAsync(T entity, CancellationToken cancellationToken = default);
    Task<List<T>> ListAsync(Expression<Func<T, bool>> expression = null, CancellationToken cancellationToken = default);
    Task<T> GetByIdAsync(R id, CancellationToken cancellationToken = default);
    Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}