using DiscountDemo.Domain;

namespace DiscountDemo.Application.Errors;

[Serializable]
public class InvalidPriceException : DiscountDemoException
{
    private const string DefaultMessage = "The purchase amount '{0}' is invalid. It must be a non-negative value.";

    public override int ErrorCode => 1000;

    public InvalidPriceException(float purchaseAmount)
        : base(string.Format(DefaultMessage, purchaseAmount))
    {
    }

    public InvalidPriceException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
