using Initial_Clean_Architecture_With_Identity.Data.Contexts;
using Initial_Clean_Architecture_With_Identity.Domain.Entities;
using Initial_Clean_Architecture_With_Identity.Helpers.ServicesInstallers.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Initial_Clean_Architecture_With_Identity.API.ServicesInstallers;

public class IdentityServiceInstaller : IServiceInstaller
{

    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            SetPasswordOptions(options.Password);

        }).AddEntityFrameworkStores<AppDbContext>();
    }

    private void SetPasswordOptions(PasswordOptions passwordOptions)
    {
        passwordOptions.RequireUppercase = false;
        passwordOptions.RequireLowercase = false;
        passwordOptions.RequireNonAlphanumeric = false;
        passwordOptions.RequiredUniqueChars = 0;
    }
}

