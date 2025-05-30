using DiscountDemo.Domain;
using DiscountDemo.Presentation.ErrorHandling;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DiscountDemo.Presentation.ErrorHandlers;

internal class DiscountDemoExceptionHandler : IExceptionHandler<DiscountDemoException>
{
    public Task Handle(HttpContext context, DiscountDemoException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        ErrorResponseDto response = ex.ToResponseDto();

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}