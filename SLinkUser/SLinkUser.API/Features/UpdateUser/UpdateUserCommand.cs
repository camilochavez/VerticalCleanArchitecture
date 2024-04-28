using MediatR;
using SLinkUser.Domain;
using SLinkUser.Domain.DTO;

namespace SLinkUser.API.Features.UpdateUser
{
    public class UpdateUserCommand : UpdateUserDTO, IRequest<Result<bool, ErrorResponse>>
    {
    }
}
