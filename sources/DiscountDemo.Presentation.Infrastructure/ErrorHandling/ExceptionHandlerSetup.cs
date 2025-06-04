using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling;

public static class ExceptionHandlerSetup
{
    public static IApplicationBuilder UseExceptionHandlers(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }

    public static IServiceCollection AddExceptionHandlers(this IServiceCollection serviceCollection, params Assembly[] assemblies)
    {
        ExceptionHandlers handler = new();

        foreach (Assembly assembly in assemblies)
            handler.AddExceptionHandlers(assembly);

        serviceCollection.AddSingleton(handler);
        return serviceCollection;
    }

    public static IServiceCollection AddExceptionHandlers(this IServiceCollection serviceCollection, Assembly assembly)
    {
        ExceptionHandlers handler = new();
        handler.AddExceptionHandlers(assembly);

        serviceCollection.AddSingleton(handler);
        return serviceCollection;
    }

    private static void AddExceptionHandlers(this ExceptionHandlers handler, Assembly assembly)
    {
        Type handlerInterfaceType = typeof(IExceptionHandler<>);

        foreach (Type type in assembly.GetTypes())
        {
            IEnumerable<Type> implementedInterfaces = type.GetInterfaces()
                .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == handlerInterfaceType);

            foreach (Type implementedInterface in implementedInterfaces)
            {
                Type exceptionType = implementedInterface.GetGenericArguments()[0];
                handler.Add(exceptionType, type);
            }
        }
    }
}
