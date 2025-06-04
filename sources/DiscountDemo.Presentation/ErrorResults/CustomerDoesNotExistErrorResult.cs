using DiscountDemo.Application.Errors;
using DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorResults;

internal class CustomerDoesNotExistErrorResult : JsonErrorResult<CustomerDoesNotExistException>
{
    protected override int StatusCode => StatusCodes.Status400BadRequest;

    protected override ErrorBodyDto BuildBody(CustomerDoesNotExistException exception)
    {
        return new ErrorBodyDto
        {
            ErrorCode = exception.ErrorCode,
            Message = exception.Message
        };
    }
}
