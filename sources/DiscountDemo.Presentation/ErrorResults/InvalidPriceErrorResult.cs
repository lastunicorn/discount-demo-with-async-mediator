using DiscountDemo.Application.Errors;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorResults;

internal class InvalidPriceErrorResult : JsonErrorResult<InvalidPriceException>
{
    protected override int StatusCode => StatusCodes.Status400BadRequest;

    protected override ErrorBodyDto BuildBody(InvalidPriceException exception)
    {
        return new ErrorBodyDto
        {
            ErrorCode = exception.ErrorCode,
            Message = exception.Message
        };
    }
}
