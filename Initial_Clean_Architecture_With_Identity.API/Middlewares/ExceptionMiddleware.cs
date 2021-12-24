using Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Responses;
using Initial_Clean_Architecture_With_Identity.Application.Interfaces;
using Initial_Clean_Architecture_With_Identity.Domain.Entities;

namespace Initial_Clean_Architecture_With_Identity.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ILoggerService loggerService)
    {
        await BeginInvoke(context, loggerService);
    }

    private async Task BeginInvoke(HttpContext context, ILoggerService loggerService)
    {
        try
        {
            await loggerService.LogAsync(context, new Log()
            {
                LogLevel = LogLevel.Information,
                Message = nameof(context.Request)
            });

            await _next.Invoke(context);

            await loggerService.LogAsync(context, new Log()
            {
                LogLevel = LogLevel.Information,
                Message = nameof(context.Response)
            }, isResponse: true);
        }
        catch (UnauthorizedAccessException e)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            var errorResponse = new ErrorResponse();
            errorResponse.Exeption = e.Message;

            await context.Response.WriteAsJsonAsync(errorResponse);

            await loggerService.LogAsync(context, new Log()
            {
                LogLevel = LogLevel.Warning,
                Exception = e.Message,
                Message = nameof(UnauthorizedAccessException),
            }, isResponse: true);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 500;
            var errorResponse = new ErrorResponse();
            errorResponse.Exeption = e.Message;

            await context.Response.WriteAsJsonAsync(errorResponse);

            await loggerService.LogAsync(context, new Log()
            {
                LogLevel = LogLevel.Error,
                Exception = e.Message,
                Message = nameof(Exception),
            }, isResponse: true);
        }
    }


}

