using DiscountDemo.Application.Errors;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling;
using DiscountDemo.Presentation.Models;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorResults;

internal class CustomerDoesNotExistErrorResult : JsonHttpErrorResult<CustomerDoesNotExistException, ErrorResponseDto>
{
    protected override int StatusCode => StatusCodes.Status400BadRequest;

    protected override ErrorResponseDto BuildBody(CustomerDoesNotExistException exception)
    {
        return new ErrorResponseDto
        {
            ErrorCode = exception.ErrorCode,
            ErrorMessage = exception.Message
        };
    }
}
