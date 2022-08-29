using MediatR;
using Messaging.Common;
using Newtonsoft.Json;
using ConsumerApi1.Application.Commands;
using ConsumerApi1.Application.Dto;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ConsumerApi1.Service
{
    public class ConsumerService : IHostedService
    {
        
        private readonly RabbitMQSettings _rabbitSettings;
        private readonly IModel _channel;
        private readonly IMediator _mediator;
        private readonly ILogger<ConsumerService> _logger;

        public ConsumerService(RabbitMQSettings rabbitSettings, IModel channel, IMediator mediator, ILogger<ConsumerService> logger)
        {
            _rabbitSettings = rabbitSettings;
            _channel = channel;
            _mediator = mediator;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            DoStuff();
            return Task.CompletedTask;
        }

        private void DoStuff()
        {
            _channel.ExchangeDeclare(exchange: _rabbitSettings.ExchangeName, type: _rabbitSettings.ExchangeType);

            _channel.QueueDeclare(queue: "QueueName1",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            _channel.QueueBind(queue: "QueueName1",
                               exchange: _rabbitSettings.ExchangeName,
                               routingKey: "",
                               null);

            var consumerAsync = new AsyncEventingBasicConsumer(_channel);

            consumerAsync.Received += async (_, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var messageDto = JsonConvert.DeserializeObject<MessageDto>(message);
                var recieveMessageCommand = new RecieveMessageCommand { MessageDto = messageDto! };
                //HandleMessage(messageDto);
                _channel.BasicAck(ea.DeliveryTag, false);
                await _mediator.Send(recieveMessageCommand);
            };

            _channel.BasicConsume(queue: "QueueName1", autoAck: false, consumerAsync);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _channel.Dispose();
            return Task.CompletedTask;
        }
    }
}
