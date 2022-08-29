using Messaging.Common;
using Newtonsoft.Json;
using Publisher.Core.Repository;
using RabbitMQ.Client;
using System.Text;

namespace Publisher.Infrastructure.Repositories
{
    public class RabbitMQPublisherRepository : IRabbitMQPublisherRepository
    {

        private readonly IModel _channel;
        private readonly RabbitMQSettings _rabbitMQSettings;

        public RabbitMQPublisherRepository(IModel channel, RabbitMQSettings rabbitMQSettings)
        {
            _channel = channel;
            _rabbitMQSettings = rabbitMQSettings;
        }

        public void SendMessage<T>(T message) where T : class
        {
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            _channel.BasicPublish(exchange: _rabbitMQSettings.ExchangeName,
                routingKey: "",
                basicProperties: null,
                body: body);
        }
    }
}
