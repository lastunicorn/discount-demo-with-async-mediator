using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;

public abstract class JsonResponseExceptionHandler<TException, TResponseBody> : IExceptionHandler<TException>
    where TException : Exception
{
    protected abstract int StatusCode { get; }

    public Task Handle(HttpContext context, TException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        TResponseBody response = BuildResponseBody(ex);

        return response is null
            ? Task.CompletedTask
            : context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    protected abstract TResponseBody BuildResponseBody(TException ex);
}
