using DiscountDemo.Port.DataAccess;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorHandlers;

internal class DataAccessExceptionHandler : JsonResponseExceptionHandler<DataAccessException>
{
    protected override int StatusCode => StatusCodes.Status503ServiceUnavailable;

    protected override ErrorResponseDto BuildResponseBody(DataAccessException exception)
    {
        return new ErrorResponseDto
        {
            ErrorCode = exception.ErrorCode,
            Message = exception.Message
        };
    }
}
