using SLinkUser.Domain.DTO;
using SLinkUser.Host.Common;
using SLinkUser.Host.Model;
using System.Text.Json;

namespace SLinkUser.Host.Services
{
    public class UserClientService(IHttpClientFactory httpClientFactory)
    {
        public async Task<bool> ImportUsers()
        {
            using var httpClient = httpClientFactory.CreateClient(SLinkUserConst.HttpClientName);

            var httpResponseMessage = await httpClient.PostAsJsonAsync("api/importusers", SLinkUserConst.ApiJsonOptions, default);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<UserDTO[]?> GetAllUsersAsync()
        {
            using var httpClient = httpClientFactory.CreateClient(SLinkUserConst.HttpClientName);

            var httpResponseMessage = await httpClient.GetAsync("api/users");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                return await JsonSerializer.DeserializeAsync<UserDTO[]>(contentStream, SLinkUserConst.ApiJsonOptions);
            }

            return [];
        }

        public async Task<UserDTO?> GetUserByIdAsync(int userId)
        {
            using var httpClient = httpClientFactory.CreateClient(SLinkUserConst.HttpClientName);

            var httpResponseMessage = await httpClient.GetAsync($"api/user/{userId}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                return await JsonSerializer.DeserializeAsync<UserDTO>(contentStream, SLinkUserConst.ApiJsonOptions);
            }

            return new UserDTO();
        }

        public async Task<bool> UpdateUserByIdAsync(UserUpdateRequest userToUpdate)
        {
            using var httpClient = httpClientFactory.CreateClient(SLinkUserConst.HttpClientName);

            var httpResponseMessage = await httpClient.PutAsJsonAsync($"api/user", userToUpdate, SLinkUserConst.ApiJsonOptions, default);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteUserByIdAsync(int userId)
        {
            using var httpClient = httpClientFactory.CreateClient(SLinkUserConst.HttpClientName);

            var httpResponseMessage = await httpClient.DeleteAsync($"api/user/{userId}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
