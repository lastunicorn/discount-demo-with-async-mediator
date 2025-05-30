using DiscountDemo.Domain;

namespace DiscountDemo.Port.DataAccess;

public class DataAccessException : DiscountDemoException
{
    public override int ErrorCode => 2000;

    public DataAccessException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
