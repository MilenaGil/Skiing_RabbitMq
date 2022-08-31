using MediatR;
using ConsumerApi3.Application.Dto;

namespace ConsumerApi3.Application.Queries
{
    public class GetRecievedMessageQuery : IRequest<List<MessageDto>>
    {
    }
}
