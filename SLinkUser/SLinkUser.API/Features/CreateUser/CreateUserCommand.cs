using MediatR;
using SLinkUser.Domain;

namespace SLinkUser.API.Features.CreateUser
{
    public sealed class CreateUserCommand : IRequest<Result<bool, ErrorResponse>>
    {  
    }
}
