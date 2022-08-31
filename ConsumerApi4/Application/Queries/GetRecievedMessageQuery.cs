using MediatR;
using ConsumerApi4.Application.Dto;

namespace ConsumerApi4.Application.Queries
{
    public class GetRecievedMessageQuery : IRequest<List<MessageDto>>
    {
    }
}
