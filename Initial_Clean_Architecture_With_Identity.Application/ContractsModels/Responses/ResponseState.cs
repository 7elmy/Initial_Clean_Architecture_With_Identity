using Microsoft.AspNetCore.Http;

namespace Initial_Clean_Architecture_With_Identity.Application.ContractsModels.Responses;

public class ResponseState
{
    public ResponseState()
    {
        ErrorResponse = new ErrorResponse();
    }

    public ResponseState(ResponseState responseState)
    {
        ErrorResponse = responseState.ErrorResponse;
        ResponseCode = responseState.ResponseCode;
    }
    public ErrorResponse ErrorResponse { get; set; }
    public bool IsValid { get { return !ErrorResponse.ErrorMessages.Any(); } }
    public int ResponseCode { get; set; } = StatusCodes.Status200OK;
}

