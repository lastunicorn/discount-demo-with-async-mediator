using DiscountDemo.Domain;

namespace DiscountDemo.Application.Errors;

[Serializable]
public class CustomerDoesNotExistException : DiscountDemoException
{
    private const string DefaultMessage = "The customer with id '{0}' does not exist.";

    public override int ErrorCode => 1001;

    public CustomerDoesNotExistException(Guid customerId)
        : base(string.Format(DefaultMessage, customerId))
    {
    }

    public CustomerDoesNotExistException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}