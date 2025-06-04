using DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling;

internal class ExceptionHandler
{
    private readonly ErrorResultTypeCollection errorResultTypes = new();

    public void Add(Type exceptionType, Type errorResultType)
    {
        errorResultTypes.Add(exceptionType, errorResultType);
    }

    public Task Handle<T>(HttpContext context, T exception)
        where T : Exception
    {
        Type errorResultType = errorResultTypes.GetErrorResultType<T>(exception);

        if (errorResultType is not null)
        {
            object errorResultObject = Activator.CreateInstance(errorResultType);

            if (errorResultObject != null)
            {
                MethodInfo method = errorResultType.GetMethod(nameof(IErrorResult<T>.ExecuteAsync));

                if (method != null)
                    return (Task)method.Invoke(errorResultObject, [context, exception]);
            }
        }

        return HandleUnknownException(context, exception);
    }

    private static Task HandleUnknownException<T>(HttpContext context, T exception)
        where T : Exception
    {
        GenericErrorResult genericErrorResult = new();
        return genericErrorResult.ExecuteAsync(context, exception);
    }
}