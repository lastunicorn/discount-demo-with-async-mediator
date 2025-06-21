using DiscountDemo.Port.DataAccess;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling;
using DiscountDemo.Presentation.Models;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorResults;

internal class DataAccessErrorResult : JsonHttpErrorResult<DataAccessException, ErrorResponseDto>
{
    protected override int StatusCode => StatusCodes.Status503ServiceUnavailable;

    protected override ErrorResponseDto BuildBody(DataAccessException exception)
    {
        return new ErrorResponseDto
        {
            ErrorCode = exception.ErrorCode,
            ErrorMessage = exception.Message
        };
    }
}
