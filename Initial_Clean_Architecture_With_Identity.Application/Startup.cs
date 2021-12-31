using Initial_Clean_Architecture_With_Identity.Application.Interfaces;
using Initial_Clean_Architecture_With_Identity.Application.Interfaces.AccountService;
using Initial_Clean_Architecture_With_Identity.Application.Services;
using Initial_Clean_Architecture_With_Identity.Application.Services.AccountService;
using Initial_Clean_Architecture_With_Identity.Helpers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Initial_Clean_Architecture_With_Identity.Application;

public class Startup : IStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ILoggerService, LoggerService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IAccountServiceValidator, AccountServiceValidator>();
    }
}

