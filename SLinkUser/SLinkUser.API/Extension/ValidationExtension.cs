using MediatR;
using SLinkUser.API.Behavior;
using SLinkUser.Domain;

namespace SLinkUser.API.Extension
{
    public static class ValidationExtension
    {
        public static MediatRServiceConfiguration AddValidation<TRequest, TResponse>(
            this MediatRServiceConfiguration config) where TRequest : notnull
        {
            return config.AddBehavior<IPipelineBehavior<TRequest, Result<TResponse, ErrorResponse>>, ValidationBehavior<TRequest, TResponse>>();
        }
    }
}
