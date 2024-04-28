using AutoMapper;
using MediatR;
using SLinkUser.API.Service;
using SLinkUser.Domain;
using SLinkUser.Domain.Entity;
using SLinkUser.Infrastructure;

namespace SLinkUser.API.Features.CreateUser
{
    internal sealed class CreateUserHandler(IUserRepository userRepository,
                                            IMapper mapper,
                                            IExternalUserService externalUserService) :
                          IRequestHandler<CreateUserCommand, Result<bool, ErrorResponse>>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IExternalUserService _externalUserService = externalUserService;

        public async Task<Result<bool, ErrorResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var externalUsers = await _externalUserService.GetUsersAsync(cancellationToken);

            var result = externalUsers.Match(
                          users => users.ToList(),
                          failure => failure
                         );

            if (result.IsSuccess)
                return await _userRepository.AddUsersAsync(result.Value!.Select(_mapper.Map<User>), cancellationToken);
            else
                return result.Error!;
        }
    }
}
