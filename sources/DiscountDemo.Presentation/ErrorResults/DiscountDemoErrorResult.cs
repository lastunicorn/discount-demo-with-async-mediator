using DiscountDemo.Domain;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorResults;

internal class DiscountDemoErrorResult : JsonErrorResult<DiscountDemoException>
{
    protected override int StatusCode => StatusCodes.Status500InternalServerError;

    protected override ErrorBodyDto BuildBody(DiscountDemoException exception)
    {
        return new ErrorBodyDto
        {
            ErrorCode = exception.ErrorCode,
            Message = exception.Message
        };
    }
}