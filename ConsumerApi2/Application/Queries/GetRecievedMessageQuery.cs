using MediatR;
using ConsumerApi2.Application.Dto;

namespace ConsumerApi2.Application.Queries
{
    public class GetRecievedMessageQuery : IRequest<List<MessageDto>>
    {
    }
}
