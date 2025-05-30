using DiscountDemo.Application.Errors;
using DiscountDemo.Presentation.ErrorHandling;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DiscountDemo.Presentation.ErrorHandlers;

internal class CustomerDoesNotExistExceptionHandler : IExceptionHandler<CustomerDoesNotExistException>
{
    public Task Handle(HttpContext context, CustomerDoesNotExistException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        ErrorResponseDto response = ex.ToResponseDto();

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
