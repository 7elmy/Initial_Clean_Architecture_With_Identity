using Initial_Clean_Architecture_With_Identity.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Initial_Clean_Architecture_With_Identity.Domain.Entities;

public class AppUser : IdentityUser, ITrackableEntity
{

    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string FamilyName { get; set; }
    [MaxLength(100)]
    public string Role { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
    public bool IsDeleted { get; set; }

}

