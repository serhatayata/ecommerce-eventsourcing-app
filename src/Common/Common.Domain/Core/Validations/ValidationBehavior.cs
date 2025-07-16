using FluentValidation;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace Common.Domain.Core.Validations;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IValidatorFactory _validationFactory;

    public ValidationBehavior(IValidatorFactory validationFactory)
    {
        _validationFactory = validationFactory;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var validator = _validationFactory.GetValidator(request.GetType());
        var result = validator?.Validate(new ValidationContext<TRequest>(request));

        if (result != null && !result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var response = await next();

        return response;
    }
}