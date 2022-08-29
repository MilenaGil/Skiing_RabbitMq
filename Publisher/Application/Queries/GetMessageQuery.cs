using MediatR;
using Publisher.Application.Dto;

namespace Publisher.Application.Queries
{
    public class GetMessageQuery : IRequest<List<MessageDto>>
    {
    }
}
