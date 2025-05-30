namespace DiscountDemo.Domain;

[Serializable]
public abstract class DiscountDemoException : Exception
{
    public abstract int ErrorCode { get; }

    protected DiscountDemoException()
    {   
    }

    protected DiscountDemoException(string message)
        : base(message)
    {
    }

    protected DiscountDemoException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}