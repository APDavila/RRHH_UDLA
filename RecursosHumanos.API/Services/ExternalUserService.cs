using RecursosHumanos.API.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecursosHumanos.API.Services
{
    public class ExternalUserService : IExternalUserService
    {
        private readonly HttpClient _httpClient;
        public ExternalUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ExternalUser>> GetExternalUsersAsync()
        {
            var response = await _httpClient.GetAsync("https://gorest.co.in/public/v2/users");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<ExternalUser>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return users;
        }
    }
}
