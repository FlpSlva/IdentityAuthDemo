using IdentityApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IdentityApi.Configuration;

public static class JwtConfig
{
    public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var appJwtSettingsSection = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(appJwtSettingsSection);

        var jwtSettings = appJwtSettingsSection.Get<JwtSettings>();
        var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
        services.AddAuthentication(_ =>
        {
            _.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            _.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(_ =>
        {
            _.RequireHttpsMetadata = true;
            _.SaveToken = true;
            _.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = jwtSettings.ValidIn,
                ValidIssuer = jwtSettings.Issuer
            };
        });
    }

    public static void UseAuthConfiguration(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
