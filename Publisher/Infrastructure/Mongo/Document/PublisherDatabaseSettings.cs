namespace Publisher.Infrastructure.Mongo.Document
{
    public class PublisherDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PublisherCollectionName { get; set; } = null!;
    }
}
