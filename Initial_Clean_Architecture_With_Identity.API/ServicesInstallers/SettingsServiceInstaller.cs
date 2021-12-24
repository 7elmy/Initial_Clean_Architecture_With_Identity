using Initial_Clean_Architecture_With_Identity.Application.Settings;
using Initial_Clean_Architecture_With_Identity.Helpers.ServicesInstallers.Interfaces;

namespace Initial_Clean_Architecture_With_Identity.API.ServicesInstallers;

public class SettingsServiceInstaller : IServiceInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JWTSettings>(options => configuration.GetSection(nameof(JWTSettings)).Bind(options));
    }
}

