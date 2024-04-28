using MediatR;
using SLinkUser.Domain;
using SLinkUser.Domain.DTO;

namespace SLinkUser.API.Features.GetUser
{
    public class GetUserQuery : IRequest<Result<List<UserDTO>, ErrorResponse>>
    {
    }
}
