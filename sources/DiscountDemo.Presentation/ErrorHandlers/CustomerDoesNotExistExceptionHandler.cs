using DiscountDemo.Application.Errors;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorHandlers;

internal class CustomerDoesNotExistExceptionHandler : JsonResponseExceptionHandler<CustomerDoesNotExistException>
{
    protected override int StatusCode => StatusCodes.Status400BadRequest;

    protected override ErrorResponseDto BuildResponseBody(CustomerDoesNotExistException exception)
    {
        return new ErrorResponseDto
        {
            ErrorCode = exception.ErrorCode,
            Message = exception.Message
        };
    }
}
