using Carter;
using MediatR;

namespace SLinkUser.API.Features.GetUserById
{
    public class GetUserByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/user/{userId}", async (int userId, ISender sender) =>
            {
                var result = await sender.Send(new GetUserByIdQuery(userId));
                return result.Match(
                        user => Results.Ok(user),
                        failed => Results.Problem(failed.Description)
                       );
            });
        }
    }
}
