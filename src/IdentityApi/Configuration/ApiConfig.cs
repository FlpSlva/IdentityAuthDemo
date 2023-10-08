using IdentityApi.Extensions;

namespace IdentityApi.Configuration;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddIdentityConfiguration(configuration);

        services.ResolveDependence();

        services.AddControllers();
        services.Configure<UrlAddress>(configuration);
        services.AddSwaggerConfiguration();

        return services;
    }

    public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwaggerConfiguration();
        }

        app.UseAuthConfiguration();

        return app;
    }
}
