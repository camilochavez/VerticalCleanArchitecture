using AutoMapper;
using MediatR;
using SLinkUser.Domain;
using SLinkUser.Domain.DTO;
using SLinkUser.Infrastructure;

namespace SLinkUser.API.Features.GetUserById
{
    public class GetUserByIdHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetUserByIdQuery, Result<UserDTO, ErrorResponse>>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<UserDTO, ErrorResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(request.Id, cancellationToken);
                var result = user.Match(
                                usersOk => usersOk,
                                failure => failure
                             );
                if (result.IsSuccess)
                    return _mapper.Map<UserDTO>(result.Value);
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
