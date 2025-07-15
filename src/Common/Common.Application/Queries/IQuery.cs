using MediatR;

namespace Common.Application.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{ }