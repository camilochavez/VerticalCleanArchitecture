using FluentValidation;
using MediatR;
using SLinkUser.Domain;
using SLinkUser.Infrastructure;

namespace SLinkUser.API.Features.UpdateUser
{
    public class UpdateUserHandler(IUserRepository userRepository) :
                 IRequestHandler<UpdateUserCommand, Result<bool, ErrorResponse>>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<Result<bool, ErrorResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.UpdateUserAsync(request.Id, request.Username!, cancellationToken);
        }
    }
}
