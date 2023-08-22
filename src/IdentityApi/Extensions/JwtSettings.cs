namespace IdentityApi.Extensions;

public class JwtSettings
{
    public string Secret { get; set; }
    public string TimesExpires { get; set; }
    public string Issuer { get; set; }
    public string ValidIn { get; set; } 
}
