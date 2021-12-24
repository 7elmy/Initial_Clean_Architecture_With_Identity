using Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Requests;
using Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Responses;

namespace Initial_Clean_Architecture_With_Identity.Application.Interfaces.AccountService;

public interface IAccountService
{
    Task<RegistrationResponse> RegisterAsync(UserRegistrationRequest model);
    Task<LoginResponse> LoginAsync(string email, string password);
}

