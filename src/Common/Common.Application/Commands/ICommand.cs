using MediatR;

namespace Common.Application.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse>
{ }

public interface ICommand : IRequest
{ }