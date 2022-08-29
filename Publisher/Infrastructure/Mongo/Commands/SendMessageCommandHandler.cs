using MediatR;
using Publisher.Application.Commands;
using Publisher.Infrastructure.Repositories;

namespace Publisher.Infrastructure.Mongo.Commands
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
    {
        private readonly RabbitMQPublisherRepository _rabbitMQPublisherRepository;
        public SendMessageCommandHandler(RabbitMQPublisherRepository rabbitMQPublisherRepository)
        {
            _rabbitMQPublisherRepository = rabbitMQPublisherRepository;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            await Task.Yield();
            _rabbitMQPublisherRepository.SendMessage(request.MessageDto);
            return Unit.Value;
        }
    }
}
