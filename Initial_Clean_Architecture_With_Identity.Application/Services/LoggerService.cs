using Initial_Clean_Architecture_With_Identity.Application.Interfaces;
using Initial_Clean_Architecture_With_Identity.Domain.Entities;
using Initial_Clean_Architecture_With_Identity.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace Initial_Clean_Architecture_With_Identity.Application.Services;

public class LoggerService : ILoggerService
{
    private IUnitOfWork _unitOfWork;

    public LoggerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<int> LogAsync(Log log)
    {
        return AddLog(log);
    }

    public Task<int> LogAsync(HttpContext context, Log log, bool isResponse)
    {
        log.Path = context.Request.Path;
        log.Method = context.Request.Method;
        log.TraceIdentifier = context.TraceIdentifier;
        if (isResponse)
        {
            log.ResponseStatusCode = (int)context.Response.StatusCode;
            log.ResponseStatusMessage = ReasonPhrases.GetReasonPhrase(log.ResponseStatusCode);
        }
        return AddLog(log);
    }

    private Task<int> AddLog(Log log)
    {
        var logRepo = _unitOfWork.GetRepository<Log>();
        logRepo.AddAsync(log);

        return _unitOfWork.SaveChangesAsync();
    }
}

