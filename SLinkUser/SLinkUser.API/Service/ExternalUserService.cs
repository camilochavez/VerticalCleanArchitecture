using SLinkUser.Domain;
using SLinkUser.Domain.DTO;

namespace SLinkUser.API.Service
{
    public interface IExternalUserService
    {
        public Task<Result<IEnumerable<UserDTO>, ErrorResponse>> GetUsersAsync(CancellationToken cancellationToken);
    }
    public class ExternalUserService : IExternalUserService
    {
        private readonly HttpClient _httpClient;

        public ExternalUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<IEnumerable<UserDTO>, ErrorResponse>> GetUsersAsync(CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.GetAsync(requestUri: "https://jsonplaceholder.typicode.com/users",
                                                          cancellationToken: cancellationToken);
                response.EnsureSuccessStatusCode();
                var users = await response.Content
                                          .ReadFromJsonAsync<IEnumerable<UserDTO>>(cancellationToken: cancellationToken);
                if (users is null)
                    return new ErrorResponse(Code: StatusErrorCode.NotFound, Description: "Users not found");

                return users.ToList();

            }
            catch (Exception ex)
            {
                return new ErrorResponse(Code: StatusErrorCode.InternalServerError, Description: ex.Message);
            }
        }
    }
}
