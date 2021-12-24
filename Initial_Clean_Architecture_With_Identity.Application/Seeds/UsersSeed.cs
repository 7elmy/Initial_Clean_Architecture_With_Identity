using Initial_Clean_Architecture_With_Identity.Application.Constants;
using Initial_Clean_Architecture_With_Identity.Application.Settings;
using Initial_Clean_Architecture_With_Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Initial_Clean_Architecture_With_Identity.Application.Seeds;

public static class UsersSeed
{
    public static void Seed(UserManager<AppUser> userManager, SuperAdminSettings superAdminSettings)
    {

        string email = superAdminSettings.Email;

        if (userManager.FindByEmailAsync(email).Result == null)
        {
            var user = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = superAdminSettings.FirstName,
                FamilyName = superAdminSettings.FamilyName,
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                Role = RolesConst.SuperAdmin
            };
            //ensure that there is only 1 super admin
            var superAdmins = userManager.GetUsersInRoleAsync(RolesConst.SuperAdmin).Result;
            if (superAdmins.Count > 0)
                return;
            //this password should be reset after publish
            var result = userManager.CreateAsync(user, Guid.NewGuid().ToString()).Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, RolesConst.SuperAdmin).Wait();
            }
        }
    }
}

