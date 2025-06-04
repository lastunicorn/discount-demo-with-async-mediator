using Microsoft.AspNetCore.Builder;

namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseExceptionHandlers(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
