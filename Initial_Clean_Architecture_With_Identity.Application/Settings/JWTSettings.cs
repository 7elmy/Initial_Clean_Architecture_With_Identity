namespace Initial_Clean_Architecture_With_Identity.Application.Settings;

public class JWTSettings
{
    public string Secret { get; set; }
    public TimeSpan TokenLifeTime { get; set; }
    public string Issuer { get; set; }
}

