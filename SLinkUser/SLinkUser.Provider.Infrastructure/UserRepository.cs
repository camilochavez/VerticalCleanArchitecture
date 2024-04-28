using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SLinkUser.Domain;
using SLinkUser.Domain.Entity;

namespace SLinkUser.Infrastructure
{
    public class UserRepository(UserDbContext userContext) : IUserRepository
    {
        private readonly UserDbContext _userContext = userContext;

        public async Task<Result<bool, ErrorResponse>> AddUsersAsync(IEnumerable<User> users, CancellationToken cancellationToken)
        {
            try
            {
                if (_userContext.Users is not null && _userContext.Users.Any())
                {
                    var usersToDelete = await _userContext.Users.
                                       Include(nameof(Address)).
                                       Include(nameof(Company)).ToListAsync(cancellationToken);
                    _userContext.RemoveRange(usersToDelete);
                    await _userContext.SaveChangesAsync(cancellationToken);
                }
                await _userContext.AddRangeAsync(users, cancellationToken);
                _userContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.InnerException switch
                {
                    ArgumentException or SqlException => new ErrorResponse(Code: StatusErrorCode.InternalServerError, Description: ex.InnerException.Message),
                    _ => new ErrorResponse(Code: StatusErrorCode.InternalServerError, Description: ex.Message)
                };
            }
            return true;
        }

        public async Task<Result<bool, ErrorResponse>> DeleteUserAsync(int userId, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userContext.Users!.
                                  Include(nameof(Address)).
                                  Include(nameof(Company)).
                                  SingleAsync(u => u.Id == userId, cancellationToken);
                _userContext.Remove(user);
                return await _userContext.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (Exception ex)
            {
                return new ErrorResponse(Code: StatusErrorCode.InternalServerError, Description: ex.Message);
            }
        }

        public async Task<Result<IEnumerable<User>, ErrorResponse>> GetUsersAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _userContext.Users!.
                                  Include(nameof(Address)).
                                  Include(nameof(Company)).
                                  ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new ErrorResponse(Code: StatusErrorCode.InternalServerError, Description: ex.Message);
            }
        }

        public async Task<Result<User, ErrorResponse>> GetUserByIdAsync(int userId, CancellationToken cancellationToken)
        {
            try
            {
                return await _userContext.Users!.SingleAsync(u => u.Id == userId, cancellationToken);
            }
            catch (Exception ex)
            {
                return new ErrorResponse(Code: StatusErrorCode.InternalServerError, Description: ex.Message);
            }
        }

        public async Task<Result<bool, ErrorResponse>> UpdateUserAsync(int userId, string? userName, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userContext.Users!.SingleAsync(user => user.Id == userId, cancellationToken);
                user.Username = userName;
                return await _userContext.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (Exception ex)
            {
                return new ErrorResponse(Code: StatusErrorCode.InternalServerError, Description: ex.Message);
            }
        }
    }
}
