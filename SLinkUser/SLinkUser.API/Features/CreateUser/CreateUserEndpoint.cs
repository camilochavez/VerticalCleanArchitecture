using Carter;
using MediatR;
using SLinkUser.Domain;

namespace SLinkUser.API.Features.CreateUser
{
    public class CreateUserEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/importusers", async (ISender sender) =>
            {
                var command = new CreateUserCommand();

                Result<bool, ErrorResponse> result = await sender.Send(command);

                return result.Match(
                        success => Results.Ok(success),
                        failed => Results.Problem(failed.Description)
                       );
            });
        }
    }
}
