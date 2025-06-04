using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;

internal class GenericExceptionHandler : JsonResponseExceptionHandler<Exception, ErrorResponseDto>
{
    protected override int StatusCode => StatusCodes.Status500InternalServerError;

    protected override ErrorResponseDto BuildResponseBody(Exception ex)
    {
        return new ErrorResponseDto
        {
            ErrorCode = 0,
            Message = $"An unexpected error occurred.",
        };
    }
}
