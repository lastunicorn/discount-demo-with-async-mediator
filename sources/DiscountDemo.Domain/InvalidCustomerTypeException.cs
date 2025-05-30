namespace DiscountDemo.Domain;

[Serializable]
public class InvalidCustomerTypeException : DiscountDemoException
{
    private const string DefaultMessage = "Invalid customer type: {0}";

    public override int ErrorCode => 1002;

    public InvalidCustomerTypeException(CustomerType customerType)
        : base(string.Format(DefaultMessage, customerType))
    {
    }

    public InvalidCustomerTypeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}