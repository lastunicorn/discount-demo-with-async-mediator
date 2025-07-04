﻿using System.Reflection;

namespace DiscountDemo.Presentation.Infrastructure.ErrorHandling;

public class ExceptionsHandlerOptions
{
    public Assembly Assembly
    {
        get => Assemblies?.First();
        set => Assemblies = value is not null
            ? [value]
            : null;
    }

    public IEnumerable<Assembly> Assemblies { get; set; }

    public IHttpErrorResult<Exception> DefaultErrorResult { get; set; }
}
