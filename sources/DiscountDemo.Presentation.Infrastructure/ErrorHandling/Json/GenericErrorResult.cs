using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;

internal class GenericErrorResult : JsonErrorResult<Exception, ErrorBodyDto>
{
    protected override int StatusCode => StatusCodes.Status500InternalServerError;

    protected override ErrorBodyDto BuildBody(Exception ex)
    {
        return new ErrorBodyDto
        {
            ErrorCode = 0,
            Message = $"An unexpected error occurred.",
        };
    }
}
