using MediatR;
using Publisher.Application.Dto;
using Publisher.Application.Queries;
using Publisher.Core.Repository;

namespace Publisher.Infrastructure.Mongo.Queries
{
    public class GetMessageQueryHandler : IRequestHandler<GetMessageQuery, List<MessageDto>>
    {
        private readonly IPublisherRepository _publisherRepository;
        public GetMessageQueryHandler(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        public async Task<List<MessageDto>> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            return await _publisherRepository.GetAllAsync();
        }
    }
}
