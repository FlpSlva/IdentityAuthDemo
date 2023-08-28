using IdentityApi.services;

namespace IdentityApi.Configuration;

public static class DependencyInjectionConfig
{
    public static void ResolveDependence(this IServiceCollection services)
    {

        services.AddHttpClient<IAuthenticateService, AuthenticateService>();
    }
}
