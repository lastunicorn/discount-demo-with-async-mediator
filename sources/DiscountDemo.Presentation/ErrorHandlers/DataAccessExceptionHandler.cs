using DiscountDemo.Port.DataAccess;
using DiscountDemo.Presentation.ErrorHandling;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DiscountDemo.Presentation.ErrorHandlers;

internal class DataAccessExceptionHandler : IExceptionHandler<DataAccessException>
{
    public Task Handle(HttpContext context, DataAccessException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;

        ErrorResponseDto response = ex.ToResponseDto();

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
