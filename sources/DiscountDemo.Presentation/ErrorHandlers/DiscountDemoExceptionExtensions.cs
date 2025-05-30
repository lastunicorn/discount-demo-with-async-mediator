using DiscountDemo.Domain;
using DiscountDemo.Presentation.ErrorHandling;

namespace DiscountDemo.Presentation.ErrorHandlers;

internal static class DiscountDemoExceptionExtensions
{
    public static ErrorResponseDto ToResponseDto(this DiscountDemoException exception)
    {
        return new ErrorResponseDto
        {
            ErrorCode = exception.ErrorCode,
            Message = exception.Message
        };
    }
}