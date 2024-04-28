using FluentValidation;
using MediatR;
using SLinkUser.Domain;


namespace SLinkUser.API.Behavior
{
    public class ValidationBehavior<TRequest, TResult>(IValidator<TRequest> validator) : IPipelineBehavior<TRequest, Result<TResult, ErrorResponse>>
    {
        private readonly IValidator<TRequest> _validator = validator;
        public async Task<Result<TResult, ErrorResponse>> Handle(TRequest request, RequestHandlerDelegate<Result<TResult, ErrorResponse>> next, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new ErrorResponse(StatusCodes.Status400BadRequest, string.Join("| ", validationResult.Errors));
            }
            return await next();
        }
    }
}
