using Initial_Clean_Architecture_With_Identity.Helpers.ServicesInstallers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Initial_Clean_Architecture_With_Identity.Helpers.ServicesInstallers.Extensions;

public static class InstallerServiceExtension
{
    public static void InstallServices(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {
        var installers = assembly.ExportedTypes.Where(x =>
          typeof(IServiceInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(
            Activator.CreateInstance).Cast<IServiceInstaller>().ToList();

        installers.ForEach(installer => installer.InstallService(services, configuration));
    }
}

