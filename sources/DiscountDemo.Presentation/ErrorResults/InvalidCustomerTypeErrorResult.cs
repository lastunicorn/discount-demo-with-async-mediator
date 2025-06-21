using DiscountDemo.Domain;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling;
using DiscountDemo.Presentation.Models;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorResults;

internal class InvalidCustomerTypeErrorResult : JsonHttpErrorResult<InvalidCustomerTypeException, ErrorResponseDto>
{
    protected override int StatusCode => StatusCodes.Status422UnprocessableEntity;

    protected override ErrorResponseDto BuildBody(InvalidCustomerTypeException exception)
    {
        return new ErrorResponseDto
        {
            ErrorCode = exception.ErrorCode,
            ErrorMessage = exception.Message
        };
    }
}
