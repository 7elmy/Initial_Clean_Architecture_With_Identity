using Initial_Clean_Architecture_With_Identity.API.Constants.ApiUrlsConst;
using Initial_Clean_Architecture_With_Identity.API.Extensions;
using Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Requests;
using Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Responses;
using Initial_Clean_Architecture_With_Identity.Application.Interfaces;
using Initial_Clean_Architecture_With_Identity.Application.Interfaces.AccountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Initial_Clean_Architecture_With_Identity.API.Controllers;

[ApiController]
[Route(BaseUrlConst.BaseUrl)]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly ILoggerService _loggerService;

    public AccountController(IAccountService accountService, ILoggerService loggerService)
    {
        _accountService = accountService;
        _loggerService = loggerService;
    }

    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorResponse))]
    [HttpPost(AccountUrlsConst.Register)]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegistrationRequest request)
    {
        var response = await _accountService.RegisterAsync(request);
        return response.GenerateResponse(_loggerService, HttpContext);
    }


    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResponse))]
    [HttpPost(AccountUrlsConst.Login)]
    public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequest request)
    {
        var response = await _accountService.LoginAsync(request.Email, request.Password);
        return response.GenerateResponse(_loggerService, HttpContext);
    }

}

