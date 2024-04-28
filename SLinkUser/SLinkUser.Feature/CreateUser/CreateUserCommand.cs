using MediatR;
using SLinkUser.Domain;
using SLinkUser.Feature.Contracts;

namespace SLinkUser.Feature.CreateUser
{
    public sealed class CreateUserCommand : IRequest<Result<bool, ErrorResponse>>
    {
        public IEnumerable<CreateUserRequest>? Users { get; set; }
    }
}
