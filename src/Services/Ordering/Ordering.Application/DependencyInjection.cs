using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddMediaR(cfg =>
        //{
        //    cfg.RegisterServiceFromAssembly(Assembly.GetExecutingAssembly());
        //});

        return services;
    }
}