namespace Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Responses;

public class RegistrationResponse : ResponseState
{
    public RegistrationResponse()
    {

    }
    public RegistrationResponse(ResponseState responseState) : base(responseState)
    {

    }
    public string Email { get; set; }
}

