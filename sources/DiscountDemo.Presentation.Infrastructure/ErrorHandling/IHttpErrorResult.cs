using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling;

public interface IHttpErrorResult<in T>
    where T : Exception
{
    Task ExecuteAsync(HttpContext context, T ex);
}