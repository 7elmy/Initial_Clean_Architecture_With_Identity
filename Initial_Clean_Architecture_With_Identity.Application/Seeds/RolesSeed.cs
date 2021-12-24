using Initial_Clean_Architecture_With_Identity.Application.Constants;
using Microsoft.AspNetCore.Identity;

namespace Initial_Clean_Architecture_With_Identity.Application.Seeds;

public static class RolesSeed
{

    public static void Seed(RoleManager<IdentityRole> roleManager)
    {
        var props = typeof(RolesConst).GetFields();

        foreach (var prop in props)
        {
            var roleName = prop.GetValue(typeof(RolesConst)).ToString();

            if (!roleManager.RoleExistsAsync(roleName).Result)
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };

                roleManager.CreateAsync(role).Wait();
            }

        }
    }
}

