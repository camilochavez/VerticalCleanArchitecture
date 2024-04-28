using Carter;
using MediatR;
using SLinkUser.Domain;

namespace SLinkUser.API.Features.DeleteUser
{
    public class DeleteUserEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("api/user/{userId}", async (int userId, ISender sender) =>
            {
                DeleteUserCommand command = new() { Id = userId };

                Result<bool, ErrorResponse> result = await sender.Send(command);

                return result.Match(
                        success => Results.Ok(success),
                        failed => Results.Problem(failed.Description)
                       );
            });
        }
    }
}
