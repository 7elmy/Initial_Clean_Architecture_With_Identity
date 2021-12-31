using Initial_Clean_Architecture_With_Identity.Domain.Entities.Common;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Initial_Clean_Architecture_With_Identity.Domain.Entities;

public class Log : ICreationDate
{
    public long Id { get; set; }
    public LogLevel LogLevel { get; set; }
    public string Message { get; set; }
    public string? Exception { get; set; }
    [MaxLength(300)]
    public string? Path { get; set; }
    [MaxLength(100)]
    public string? Method { get; set; }
    public string? UserName { get; set; }
    public string? Proprties { get; set; }
    public DateTime CreationDate { get; set; }
    public int ResponseStatusCode { get; set; }
    public string? ResponseStatusMessage { get; set; }
    public string? TraceIdentifier { get; set; }
}

