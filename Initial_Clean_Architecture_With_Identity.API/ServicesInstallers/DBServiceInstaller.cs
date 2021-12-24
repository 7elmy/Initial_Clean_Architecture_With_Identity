using Initial_Clean_Architecture_With_Identity.Data.Contexts;
using Initial_Clean_Architecture_With_Identity.Helpers.ServicesInstallers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Initial_Clean_Architecture_With_Identity.API.ServicesInstallers;

public class DBServiceInstaller : IServiceInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AppConnection")));
    }
}

