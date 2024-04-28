using SLinkUser.Domain;
using SLinkUser.Domain.Entity;

namespace SLinkUser.Infrastructure
{
    public interface IUserRepository
    {
        public Task<Result<bool, ErrorResponse>> AddUsersAsync(IEnumerable<User> providers, CancellationToken cancellationToken);
        public Task<Result<IEnumerable<User>, ErrorResponse>> GetUsersAsync(CancellationToken cancellationToken);
        public Task<Result<User, ErrorResponse>> GetUserByIdAsync(int userId, CancellationToken cancellationToken);
        public Task<Result<bool, ErrorResponse>> UpdateUserAsync(int userId, string userName, CancellationToken cancellationToken);
        public Task<Result<bool, ErrorResponse>> DeleteUserAsync(int userId, CancellationToken cancellationToken);

    }
}