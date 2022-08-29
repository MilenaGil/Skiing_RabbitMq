using MediatR;
using Publisher.Application.Commands;
using Publisher.Core.Repository;

namespace Publisher.Infrastructure.Mongo.Commands
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand>
    {
        private readonly IPublisherRepository _publisherRepository;
        public CreateMessageCommandHandler(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            await _publisherRepository.CreateAsync(request.MessageDto);
            return Unit.Value;
        }
    }
}
