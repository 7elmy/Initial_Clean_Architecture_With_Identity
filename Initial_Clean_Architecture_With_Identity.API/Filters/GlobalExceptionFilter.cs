using Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Responses;
using Initial_Clean_Architecture_With_Identity.Application.Interfaces;
using Initial_Clean_Architecture_With_Identity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Initial_Clean_Architecture_With_Identity.API.Filters;

public class GlobalExceptionFilter : Attribute, IExceptionFilter
{
    private readonly ILoggerService _loggerService;

    public GlobalExceptionFilter(ILoggerService loggerService)
    {
        _loggerService = loggerService;
    }

    public void OnException(ExceptionContext context)
    {
        context.ExceptionHandled = true;

        var exception = context.Exception.Message;

        if (context.Exception is Exception)
        {
            var errorResponse = new ErrorResponse();
            errorResponse.Exeption = exception;
            context.Result = new BadRequestObjectResult(errorResponse);
        }

        _loggerService.LogAsync(context.HttpContext, new Log()
        {
            Exception = exception,
            Message = nameof(Exception),
            LogLevel = LogLevel.Warning,
        }, isResponse: true);
    }
}

