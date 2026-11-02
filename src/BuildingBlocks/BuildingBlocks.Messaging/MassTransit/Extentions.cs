using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Messaging.MassTransit;

public static class Extentions
{
    public static IServiceCollection AddMessageBroker
        (this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
    {
        // Implement RabbitMQ Masstransit configuration
        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter(); // vd: BasketCheckoutConsumer => basket-checkout

            if (assembly != null)
            {
                config.AddConsumers(assembly); // Auto-discovery
            }

            config.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(configuration["MessageBroker:Host"]!), host =>
                {
                    host.Username(configuration["MessageBroker:UserName"]!);
                    host.Password(configuration["MessageBroker:Password"]!);
                });
                configurator.ConfigureEndpoints(context); //Nó sẽ tự động kết nối lên RabbitMQ: tạo Exchange, tạo Queue theo tên chuẩn kebab-case, và thực hiện **Binding** giữa Exchange với Queue tương ứng cho tất cả các Consumer vừa quét được ở bước 3
            });
        });

        return services;
    }
}