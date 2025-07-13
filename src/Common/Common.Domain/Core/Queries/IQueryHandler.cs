using MediatR;

namespace Common.Domain.Core.Queries;

public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IQuery<TResponse>
{ }