using MediatR;
using SLinkUser.Domain;
using SLinkUser.Infrastructure;

namespace SLinkUser.API.Features.DeleteUser
{
    public class DeleteUserHandler(IUserRepository userRepository) :
                 IRequestHandler<DeleteUserCommand, Result<bool, ErrorResponse>>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<Result<bool, ErrorResponse>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteUserAsync(request.Id, cancellationToken);
        }
    }
}
