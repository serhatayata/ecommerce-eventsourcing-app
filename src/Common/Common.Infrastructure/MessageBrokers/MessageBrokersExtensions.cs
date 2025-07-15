using Common.Domain.MessageBrokers;
using Common.Infrastructure.MessageBrokers.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure.MessageBrokers;

public static class MessageBrokersExtensions
{
    public static IServiceCollection AddMessageBroker(this IServiceCollection services, IConfiguration Configuration)
    {
        var options = new MessageBrokersOptions();
        Configuration.GetSection(nameof(MessageBrokersOptions)).Bind(options);
        services.Configure<MessageBrokersOptions>(Configuration.GetSection(nameof(MessageBrokersOptions)));

        switch (options.MessageBrokerType.ToLowerInvariant())
        {
            case "rabbitmq":
                return services.AddRabbitMQ(Configuration);
            default:
                throw new Exception($"Message broker type '{options.MessageBrokerType}' is not supported");
        }
    }
}