using MediatR;
using ConsumerApi1.Application.Dto;

namespace ConsumerApi1.Application.Queries
{
    public class GetRecievedMessageQuery : IRequest<List<MessageDto>>
    {
    }
}
