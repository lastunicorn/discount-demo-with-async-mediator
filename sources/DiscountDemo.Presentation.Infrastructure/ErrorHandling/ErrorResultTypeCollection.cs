namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling;

internal class ErrorResultTypeCollection
{
    private readonly Dictionary<Type, Type> types = [];

    public void Add(Type exceptionType, Type errorResponseType)
    {
        ArgumentNullException.ThrowIfNull(exceptionType);
        ArgumentNullException.ThrowIfNull(errorResponseType);

        if (!IsExceptionType(exceptionType))
            throw new ArgumentException($"The type {exceptionType.FullName} must inherit from System.Exception.", nameof(exceptionType));

        bool isErrorResponseType = IsErrorResponseType(exceptionType, errorResponseType);
        if (!isErrorResponseType)
            throw new ArgumentException($"The type {errorResponseType.FullName} must implement IErrorResult<{exceptionType.Name}>.", nameof(errorResponseType));

        types.Add(exceptionType, errorResponseType);
    }

    private static bool IsExceptionType(Type exceptionType)
    {
        return exceptionType.IsSubclassOf(typeof(Exception));
    }

    private static bool IsErrorResponseType(Type exceptionType, Type errorResponseType)
    {
        Type interfaceType = typeof(IErrorResult<>).MakeGenericType(exceptionType);
        return interfaceType.IsAssignableFrom(errorResponseType);
    }

    public Type GetErrorResultType<T>(T exception)
    {
        bool success = types.TryGetValue(exception.GetType(), out Type errorResultType);

        return success
            ? errorResultType
            : null;
    }
}
