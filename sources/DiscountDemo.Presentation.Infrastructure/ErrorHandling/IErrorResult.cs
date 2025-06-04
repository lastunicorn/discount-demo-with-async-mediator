using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling;

public interface IErrorResult<in T>
    where T : Exception
{
    Task ExecuteAsync(HttpContext context, T ex);
}