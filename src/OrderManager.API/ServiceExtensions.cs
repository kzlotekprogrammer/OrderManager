﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OrderManager.API;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterRequestHandlers(this IServiceCollection services)
    {
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
