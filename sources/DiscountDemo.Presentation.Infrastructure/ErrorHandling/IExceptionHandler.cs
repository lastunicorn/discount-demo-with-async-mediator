using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.ErrorHandling;

public interface IExceptionHandler<in T>
    where T : Exception
{
    Task Handle(HttpContext context, T ex);
}