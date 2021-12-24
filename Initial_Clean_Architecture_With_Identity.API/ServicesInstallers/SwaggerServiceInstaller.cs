using Initial_Clean_Architecture_With_Identity.Application.Settings;
using Initial_Clean_Architecture_With_Identity.Helpers.ServicesInstallers.Interfaces;
using Microsoft.OpenApi.Models;

namespace Initial_Clean_Architecture_With_Identity.API.ServicesInstallers;

public class SwaggerServiceInstaller : IServiceInstaller
{
    private readonly SwaggerSettings _swaggerSettings;

    public SwaggerServiceInstaller()
    {
        _swaggerSettings = new SwaggerSettings();
    }
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        configuration.GetSection(_swaggerSettings.GetType().Name).Bind(_swaggerSettings);

        services.AddSwaggerGen(c =>
        {
                //swagger doc name is related to UIEndpoint
                c.SwaggerDoc(_swaggerSettings.Version, new OpenApiInfo { Title = _swaggerSettings.Title, Version = _swaggerSettings.Version });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description =
  "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
        });
    }
}

