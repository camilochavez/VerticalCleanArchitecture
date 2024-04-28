using Carter;
using MediatR;

namespace SLinkUser.API.Features.GetUser
{
    public class GetUserEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/users", async (ISender sender) =>
            {
                var result = await sender.Send(new GetUserQuery());
                return result.Match(
                        users => Results.Ok(users),
                        failed => Results.Problem(failed.Description)
                       );
            });
        }
    }
}
