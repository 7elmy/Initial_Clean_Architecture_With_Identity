namespace Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Responses;

public class LoginResponse : ResponseState
{
    public LoginResponse()
    {

    }
    public LoginResponse(ResponseState responseState) : base(responseState)
    {

    }
    public string Token { get; set; }
}

