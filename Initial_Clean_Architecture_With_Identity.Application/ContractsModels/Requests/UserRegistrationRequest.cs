namespace Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Requests;

public class UserRegistrationRequest
{
    public string FirstName { get; set; }
    public string FamilyName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Role { get; set; }
}

