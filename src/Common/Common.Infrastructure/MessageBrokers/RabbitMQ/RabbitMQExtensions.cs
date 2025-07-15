using Common.Domain.MessageBrokers;
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

        services.AddSingleton<IEventListener, RabbitMQListener>();

        return services;
    }
}