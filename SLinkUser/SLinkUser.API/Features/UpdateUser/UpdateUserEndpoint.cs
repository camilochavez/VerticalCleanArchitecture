using AutoMapper;
using Carter;
using MediatR;
using SLinkUser.API.Features.Contract;
using SLinkUser.Domain;

namespace SLinkUser.API.Features.UpdateUser
{
    public class UpdateUserEndpoint(IMapper mapper) : ICarterModule
    {
        private readonly IMapper _mapper = mapper;
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("api/user", async (UpdateUserRequest updateUserRequest, ISender sender) =>
            {
                UpdateUserCommand command = _mapper.Map<UpdateUserCommand>(updateUserRequest);

                Result<bool, ErrorResponse> result = await sender.Send(command);

                return result.Match(
                        success => Results.Ok(success),
                        failed => Results.Problem(failed.Description)
                       );
            });
        }
    }
}
