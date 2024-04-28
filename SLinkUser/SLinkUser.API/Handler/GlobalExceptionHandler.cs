using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SLinkUser.API.Loggin;
using SLinkUser.Domain;

namespace SLinkUser.API.Handler
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger = logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                              Exception exception,
                                              CancellationToken cancellationToken)
        {
            _logger.LogInternalServerError(LogLevel.Error, exception.Message);

            var problemDetail = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = ErrorCode.InternalServerError,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
            };

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(problemDetail, cancellationToken);

            return true;
        }
    }
}
