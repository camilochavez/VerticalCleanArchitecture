using AutoMapper;
using MediatR;
using SLinkUser.Domain;
using SLinkUser.Domain.DTO;
using SLinkUser.Infrastructure;

namespace SLinkUser.API.Features.GetUser
{
    public class GetUserHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetUserQuery, Result<List<UserDTO>, ErrorResponse>>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<List<UserDTO>, ErrorResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetUsersAsync(cancellationToken);
                var result = users.Match(
                                usersOk => usersOk.ToList(),
                                failure => failure
                             );
                if (result.IsSuccess)
                    return result.Value!.Select(_mapper.Map<UserDTO>).ToList();
                else
                    return result.Error!;
            }
            catch (Exception ex)
            {
                return new ErrorResponse(Code: StatusErrorCode.InternalServerError, Description: ex.Message);
            }
        }
    }
}
