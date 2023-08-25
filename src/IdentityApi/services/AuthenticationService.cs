using IdentityApi.Models;
using System.Text;
using System.Text.Json;

namespace IdentityApi.services;

public class AuthenticateService : IAuthenticateService
{
    private readonly HttpClient _httpClient;
    public AuthenticateService(HttpClient httpClient)
        => _httpClient = httpClient;

    public async Task<CustomerResponse> Register(UserRegister userRegister)
    {
       
        var loginContent = new StringContent(
            JsonSerializer.Serialize(userRegister),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync("https://localhost:7160/api/customer/register", loginContent);

        return JsonSerializer.Deserialize<CustomerResponse>(await response.Content.ReadAsStringAsync());
    }
}
