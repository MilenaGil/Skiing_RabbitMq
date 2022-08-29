using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Messaging.Common
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection SetUpRabbitMq(this IServiceCollection services, IConfiguration config)
        {
            var configSection = config.GetSection("RabbitMQSettings");
            var settings = new RabbitMQSettings();
            configSection.Bind(settings);

            services.AddSingleton<RabbitMQSettings>(settings);

            services.AddSingleton<IConnectionFactory>(sp => new ConnectionFactory
            {
                HostName = settings.HostName,
                DispatchConsumersAsync = true
            });

            services.AddSingleton<ModelFactory>();
            services.AddSingleton(sp => sp.GetRequiredService<ModelFactory>().CreateChannel());

            return services;
        }

        public class ModelFactory : IDisposable
        {
            private readonly IConnection _connection;
            private readonly RabbitMQSettings _settings;

            public ModelFactory(IConnectionFactory connectionFactory, RabbitMQSettings settings)
            {
                _connection = connectionFactory.CreateConnection();
                _settings = settings;
            }

            public IModel CreateChannel()
            {
                var channel = _connection.CreateModel();
                channel.ExchangeDeclare(exchange: _settings.ExchangeName, type: _settings.ExchangeType);
                channel.QueueDeclare(queue: "QueueName1",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                channel.QueueDeclare(queue: "QueueName2",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                return channel;
            }

            public void Dispose()
            {
                _connection.Dispose();
            }
        }
    }
}
