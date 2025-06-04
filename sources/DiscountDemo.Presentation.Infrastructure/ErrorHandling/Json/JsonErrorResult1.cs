namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;

public abstract class JsonErrorResult<TException> : JsonErrorResult<TException, ErrorBodyDto>
    where TException : Exception
{
}