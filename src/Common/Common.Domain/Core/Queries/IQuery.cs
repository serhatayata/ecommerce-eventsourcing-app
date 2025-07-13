using MediatR;

namespace Common.Domain.Core.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{ }