using Initial_Clean_Architecture_With_Identity.API.Middlewares;

namespace Initial_Clean_Architecture_With_Identity.API.Extensions;

public static class ExceptionsExtension
{
    public static IApplicationBuilder UseExceptions(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}

