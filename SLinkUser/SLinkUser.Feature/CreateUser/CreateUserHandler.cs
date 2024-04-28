using AutoMapper;
using MediatR;
using SLinkUser.Domain;
using SLinkUser.Domain.Entity;
using SLinkUser.Infrastructure;

namespace SLinkUser.Feature.CreateUser
{
    internal sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<bool, ErrorResponse>>
    {
        private readonly UserDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserHandler(UserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<bool, ErrorResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<User>? users = request.Users?.Select(user => _mapper.Map<User>(user));

            await _dbContext.AddRangeAsync(users, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
