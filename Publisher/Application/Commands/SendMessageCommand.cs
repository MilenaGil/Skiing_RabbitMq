using MediatR;
using Publisher.Application.Dto;

namespace Publisher.Application.Commands
{
    public class SendMessageCommand : IRequest
    {
        public MessageDto MessageDto { get; set; }
    }
}
