using Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Responses;
using Initial_Clean_Architecture_With_Identity.Application.Interfaces;
using Initial_Clean_Architecture_With_Identity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Initial_Clean_Architecture_With_Identity.API.Extensions;

public static class ResponseGeneratorExtension
{
    public static IActionResult GenerateResponse(this ResponseState response, ILoggerService loggerService, HttpContext context)
    {
        object resObj = response;
        if (!response.IsValid)
        {
            resObj = response.ErrorResponse;

            loggerService.LogAsync(context, new Log()
            {
                LogLevel = LogLevel.Error,
                Message = response.ErrorResponse?.ErrorMessages[0]?.Message,
            });
        }
        var result = new ObjectResult(resObj);
        result.StatusCode = response.ResponseCode;

        return result;
    }
}

