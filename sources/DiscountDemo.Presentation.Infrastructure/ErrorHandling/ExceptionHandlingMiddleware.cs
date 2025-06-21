using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling;

internal class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;
    private readonly ExceptionsHandler exceptionHandler;

    public ExceptionHandlingMiddleware(RequestDelegate next, ExceptionsHandler exceptionHandler)
    {
        this.next = next ?? throw new ArgumentNullException(nameof(next));
        this.exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await exceptionHandler.Handle(context, ex);
        }
    }
}
