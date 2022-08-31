using MediatR;
using ConsumerApi4.Application.Dto;
using ConsumerApi4.Application.Queries;
using ConsumerApi4.Core.Repository;

namespace ConsumerApi4.Infrastructure.Mongo.Queries
{
    public class GetRecievedMessageQueryHandler : IRequestHandler<GetRecievedMessageQuery, List<MessageDto>>
    {
        private readonly IConsumerRepository _consumerRepository;
        public GetRecievedMessageQueryHandler(IConsumerRepository consumerRepository)
        {
            _consumerRepository = consumerRepository;
        }

        public async Task<List<MessageDto>> Handle(GetRecievedMessageQuery request, CancellationToken cancellationToken)
        {
            return await _consumerRepository.GetAllAsync();
        }
    }
}
