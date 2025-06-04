using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;

public abstract class JsonErrorResult<TException, TResponseBody> : IErrorResult<TException>
    where TException : Exception
{
    protected abstract int StatusCode { get; }

    public Task ExecuteAsync(HttpContext context, TException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCode;

        TResponseBody response = BuildBody(ex);

        return response is null
            ? Task.CompletedTask
            : context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    protected abstract TResponseBody BuildBody(TException ex);
}
