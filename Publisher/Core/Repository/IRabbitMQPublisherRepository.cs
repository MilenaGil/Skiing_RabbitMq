namespace Publisher.Core.Repository
{
    public interface IRabbitMQPublisherRepository
    {
        void SendMessage<T>(T message) where T : class;
    }
}
