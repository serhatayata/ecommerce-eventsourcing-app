using Common.Domain.MessageBrokers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure.MessageBrokers.RabbitMQ;

public static class RabbitMQExtensions
{
    public static IServiceCollection AddRabbitMQ(
    this IServiceCollection services,
    IConfiguration Configuration)
    {
        var options = new RabbitMQOptions();
        Configuration.GetSection(nameof(MessageBrokersOptions)).Bind(options);
        services.Configure<RabbitMQOptions>(Configuration.GetSection(nameof(MessageBrokersOptions)));

        // Add MassTransit with RabbitMQ configuration
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(options.Host, options.Port, options.VirtualHost, h =>
                {
                    h.Username(options.Username);
                    h.Password(options.Password);
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        services.AddSingleton<IEventListener, RabbitMQListener>();

        return services;
    }
}