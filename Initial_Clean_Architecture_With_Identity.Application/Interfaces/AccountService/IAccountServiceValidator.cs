using Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Requests;
using Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Responses;
using Initial_Clean_Architecture_With_Identity.Domain.Entities;

namespace Initial_Clean_Architecture_With_Identity.Application.Interfaces.AccountService;

public interface IAccountServiceValidator
{
    Task<ResponseState> RegisterValidator(UserRegistrationRequest model);
    Task<ResponseState> LoginValidator(string password, AppUser loggedinUser);
}

