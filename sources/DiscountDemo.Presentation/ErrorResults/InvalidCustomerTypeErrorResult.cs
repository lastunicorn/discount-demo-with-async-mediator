using DiscountDemo.Domain;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorResults;

internal class InvalidCustomerTypeErrorResult : JsonErrorResult<InvalidCustomerTypeException>
{
    protected override int StatusCode => StatusCodes.Status422UnprocessableEntity;

    protected override ErrorBodyDto BuildBody(InvalidCustomerTypeException exception)
    {
        return new ErrorBodyDto
        {
            ErrorCode = exception.ErrorCode,
            Message = exception.Message
        };
    }
}
