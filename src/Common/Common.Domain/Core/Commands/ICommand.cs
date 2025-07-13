using MediatR;

namespace Common.Domain.Core.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse>
{ }

public interface ICommand : IRequest
{ }