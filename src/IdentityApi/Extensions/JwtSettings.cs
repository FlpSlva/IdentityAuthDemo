namespace IdentityApi.Extensions;

public class JwtSettings
{
    public string Secret { get; set; }
    public int TimesExpires { get; set; }
    public string Issuer { get; set; }
    public string ValidIn { get; set; } 
}
