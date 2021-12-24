namespace Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Responses;

public class ErrorResponse
{
    public ErrorResponse()
    {
        ErrorMessages = new List<ErrorMessage>();
    }
    public List<ErrorMessage> ErrorMessages { get; set; }
    public string Exeption { get; set; }

    public class ErrorMessage
    {
        public string Key { get; set; }
        public string Message { get; set; }
    }
}

