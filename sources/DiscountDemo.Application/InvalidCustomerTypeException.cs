using DiscountDemo.Domain;

namespace DiscountDemo.Application;

[Serializable]
internal class InvalidCustomerTypeException : Exception
{
    private const string DefaultMessage = "Invalid customer type: {0}";

    public InvalidCustomerTypeException(CustomerType customerType)
        : base(string.Format(DefaultMessage, customerType))
    {
    }

    public InvalidCustomerTypeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}