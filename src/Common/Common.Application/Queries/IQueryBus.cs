namespace Common.Application.Queries;

public interface IQueryBus
{
    Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default(CancellationToken));
}