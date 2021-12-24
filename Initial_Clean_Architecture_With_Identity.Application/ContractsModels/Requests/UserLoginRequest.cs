using System.ComponentModel.DataAnnotations;

namespace Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Requests;

public class UserLoginRequest
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}

