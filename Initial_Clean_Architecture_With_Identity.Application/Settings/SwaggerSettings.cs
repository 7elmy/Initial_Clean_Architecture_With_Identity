namespace Initial_Clean_Architecture_With_Identity.Application.Settings;

public class SwaggerSettings
{
    public string Title { get; set; }
    public string Version { get; set; }
    public string UIEndpoint { get { return "/swagger/" + Version + "/swagger.json"; } }
}

