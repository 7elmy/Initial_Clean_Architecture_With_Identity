using Initial_Clean_Architecture_With_Identity.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Initial_Clean_Architecture_With_Identity.Application.Interfaces;

public interface ILoggerService
{
    Task<int> LogAsync(Log log);
    Task<int> LogAsync(HttpContext context, Log log, bool isResponse = false);
}

