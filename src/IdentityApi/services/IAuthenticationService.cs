using IdentityApi.Models;

namespace IdentityApi.services;

public interface IAuthenticateService
{
    Task<CustomerResponse> Register(UserRegister userRegister);
}
