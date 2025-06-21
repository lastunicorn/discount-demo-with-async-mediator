using DiscountDemo.Domain;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling;
using DiscountDemo.Presentation.Models;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorResults;

internal class DiscountDemoErrorResult : JsonHttpErrorResult<DiscountDemoException, ErrorResponseDto>
{
    protected override int StatusCode => StatusCodes.Status500InternalServerError;

    protected override ErrorResponseDto BuildBody(DiscountDemoException exception)
    {
        return new ErrorResponseDto
        {
            ErrorCode = exception.ErrorCode,
            ErrorMessage = exception.Message
        };
    }
}