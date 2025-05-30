using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DiscountDemo.Presentation.ErrorHandling;

internal class GenericExceptionHandler : IExceptionHandler<Exception>
{
    public Task Handle(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        ErrorResponseDto response = new()
        {
            ErrorCode = 0,
            Message = $"An unexpected error occurred.",
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}