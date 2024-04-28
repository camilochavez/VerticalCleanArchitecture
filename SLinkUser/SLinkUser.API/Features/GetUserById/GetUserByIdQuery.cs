using MediatR;
using SLinkUser.Domain.DTO;
using SLinkUser.Domain;

namespace SLinkUser.API.Features.GetUserById
{
    public record GetUserByIdQuery(int Id) : IRequest<Result<UserDTO, ErrorResponse>>;
}
