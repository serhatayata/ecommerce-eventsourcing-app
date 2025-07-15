namespace Common.Infrastructure.MessageBrokers.RabbitMQ;

public class RabbitMQOptions
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string VirtualHost { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}