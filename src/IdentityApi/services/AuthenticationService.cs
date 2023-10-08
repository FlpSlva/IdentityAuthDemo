using IdentityApi.Extensions;
using IdentityApi.Models;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace IdentityApi.services;

public class AuthenticateService : IAuthenticateService
{
    private readonly HttpClient _httpClient;
    public AuthenticateService(HttpClient httpClient, IOptions<UrlAddress> url)
    {
        httpClient.BaseAddress = new Uri(url.Value.UrlAddressCustomer);
       _httpClient = httpClient;
    }

    public async Task<CustomerResponse> Register(UserRegister userRegister)
    {
       
        var loginContent = new StringContent(
            JsonSerializer.Serialize(userRegister),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync("/api/customer/register", loginContent);

        return JsonSerializer.Deserialize<CustomerResponse>(await response.Content.ReadAsStringAsync())!;
    }
}
