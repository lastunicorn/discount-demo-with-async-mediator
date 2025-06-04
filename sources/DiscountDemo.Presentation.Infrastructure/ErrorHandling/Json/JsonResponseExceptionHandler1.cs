namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;

public abstract class JsonResponseExceptionHandler<TException> : JsonResponseExceptionHandler<TException, ErrorResponseDto>
    where TException : Exception
{
}