using DiscountDemo.Domain;
using DiscountDemo.Presentation.ErrorHandling;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DiscountDemo.Presentation.ErrorHandlers;

internal class InvalidCustomerTypeExceptionHandler : IExceptionHandler<InvalidCustomerTypeException>
{
    public Task Handle(HttpContext context, InvalidCustomerTypeException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;

        ErrorResponseDto response = ex.ToResponseDto();

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
