using Initial_Clean_Architecture_With_Identity.Data.Contexts;
using Initial_Clean_Architecture_With_Identity.Data.UnitOfWork;
using Initial_Clean_Architecture_With_Identity.Domain.Interfaces;
using Initial_Clean_Architecture_With_Identity.Helpers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Initial_Clean_Architecture_With_Identity.Data;

public class Startup : IStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();
    }
}

