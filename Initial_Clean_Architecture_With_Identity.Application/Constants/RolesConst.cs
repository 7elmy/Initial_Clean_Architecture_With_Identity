
using System.Collections.ObjectModel;

namespace Initial_Clean_Architecture_With_Identity.Application.Constants;

public class RolesConst
{
    /// <summary>
    /// List of all roles of all roles the system in lower case
    /// </summary>
    private static readonly ReadOnlyCollection<string> AllRoles = new ReadOnlyCollection<string>(new[]
    {
              SuperAdmin.ToLower(),
              Admin.ToLower()
        });

    public const string SuperAdmin = nameof(SuperAdmin);
    public const string Admin = nameof(Admin);


    public static bool IsExist(string role)
    {
        return AllRoles.Contains(role.Trim().ToLower());
    }
}

