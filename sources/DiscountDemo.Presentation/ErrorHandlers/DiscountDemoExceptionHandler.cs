using DiscountDemo.Domain;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorHandlers;

internal class DiscountDemoExceptionHandler : JsonResponseExceptionHandler<DiscountDemoException>
{
    protected override int StatusCode => StatusCodes.Status500InternalServerError;

    protected override ErrorResponseDto BuildResponseBody(DiscountDemoException exception)
    {
        return new ErrorResponseDto
        {
            ErrorCode = exception.ErrorCode,
            Message = exception.Message
        };
    }
}