using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace OrderManager.Core;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterRequestHandlers(this IServiceCollection services)
    {
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
