using MediatR;
using ConsumerApi2.Application.Dto;
using ConsumerApi2.Application.Queries;
using ConsumerApi2.Core.Repository;

namespace ConsumerApi2.Infrastructure.Mongo.Queries
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
