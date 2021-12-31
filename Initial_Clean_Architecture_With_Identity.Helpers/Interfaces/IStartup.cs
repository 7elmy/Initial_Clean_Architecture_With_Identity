using Microsoft.Extensions.DependencyInjection;

namespace Initial_Clean_Architecture_With_Identity.Helpers.Interfaces;

public interface IStartup
{
    void ConfigureServices(IServiceCollection services);
}

