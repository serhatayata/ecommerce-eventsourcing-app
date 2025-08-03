namespace Common.Infrastructure.Outbox.Stores.MongoDb;

public class MongoDbOutboxOptions
{
    public string CollectionName { get; set; } = "Messages";
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; } = "OutboxDb";
}