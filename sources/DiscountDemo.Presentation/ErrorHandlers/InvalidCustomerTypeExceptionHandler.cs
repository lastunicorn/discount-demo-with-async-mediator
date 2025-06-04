using DiscountDemo.Domain;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorHandlers;

internal class InvalidCustomerTypeExceptionHandler : JsonResponseExceptionHandler<InvalidCustomerTypeException>
{
    protected override int StatusCode => StatusCodes.Status422UnprocessableEntity;

    protected override ErrorResponseDto BuildResponseBody(InvalidCustomerTypeException exception)
    {
        return new ErrorResponseDto
        {
            ErrorCode = exception.ErrorCode,
            Message = exception.Message
        };
    }
}
