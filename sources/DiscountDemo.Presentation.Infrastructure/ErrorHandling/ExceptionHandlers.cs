using DiscountDemo.Presentation.Infrastructure.ErrorHandling.Json;
using Microsoft.AspNetCore.Http;

namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling;

internal class ExceptionHandlers
{
    private readonly Dictionary<Type, Type> types = [];

    public void Add(Type exceptionType, Type type)
    {
        ArgumentNullException.ThrowIfNull(exceptionType);
        ArgumentNullException.ThrowIfNull(type);

        types.Add(exceptionType, type);
    }

    public async Task Handle<T>(HttpContext context, T exception)
        where T : Exception
    {
        if (types.TryGetValue(exception.GetType(), out Type handlerType))
        {
            object handler = Activator.CreateInstance(handlerType);

            if (handler != null)
            {
                var method = handlerType.GetMethod("Handle");
                if (method != null)
                {
                    await (Task)method.Invoke(handler, [context, exception]);
                }
            }
        }
        else
        {
            // Handle unknown exceptions with a generic handler
            var genericHandler = new GenericExceptionHandler();
            await genericHandler.Handle(context, exception);
        }
    }
}