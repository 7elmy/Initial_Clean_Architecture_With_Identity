namespace Initial_Clean_Architecture_With_Identity.Application.Constants.ErrorsConst;

public class AccountErrorConst
{
    public const string UserKey = "User";
    public const string RoleKey = "Role";
    public const string PasswordKey = "Password";


    public const string EmailOrPassNotCorrect = "Email Or Password Is Not Correct";
    public const string RoleIsNotFound = "Role Is Not Found";
    public const string PasswordMatching = "Password And Confirm Password Are Not Matched";
    public const string PasswordNotValid = "Password Is Not Valid";
    public const string UserAlreadyExist = "User Already Exist";
    public const string UserFaildToCreate = "User Faild To be Created";
}
