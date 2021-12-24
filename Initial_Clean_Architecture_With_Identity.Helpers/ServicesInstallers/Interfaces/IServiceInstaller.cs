using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Initial_Clean_Architecture_With_Identity.Helpers.ServicesInstallers.Interfaces;

public interface IServiceInstaller
{
    void InstallService(IServiceCollection services, IConfiguration configuration);
}

