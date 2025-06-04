using DiscountDemo.Port.DataAccess;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorResults;

internal class DataAccessErrorResult : JsonErrorResult<DataAccessException>
{
    protected override int StatusCode => StatusCodes.Status503ServiceUnavailable;

    protected override ErrorBodyDto BuildBody(DataAccessException exception)
    {
        return new ErrorBodyDto
        {
            ErrorCode = exception.ErrorCode,
            Message = exception.Message
        };
    }
}
