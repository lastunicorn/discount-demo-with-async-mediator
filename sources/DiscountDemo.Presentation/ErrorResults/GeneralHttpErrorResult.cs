using DiscountDemo.Presentation.Infrastructure.ErrorHandling;
using DiscountDemo.Presentation.Models;

namespace DiscountDemo.Presentation.ErrorResults;

public class GeneralHttpErrorResult : JsonHttpErrorResult<Exception, ErrorResponseDto>
{
    protected override int StatusCode => 500;

    protected override ErrorResponseDto BuildBody(Exception ex)
    {
        return new ErrorResponseDto
        {
            ErrorCode = 0,
            ErrorMessage = "An unexpected error occurred. Please try again later."
        };
    }
}