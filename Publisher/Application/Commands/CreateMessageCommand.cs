using MediatR;
using Publisher.Application.Dto;

namespace Publisher.Application.Commands
{
    public class CreateMessageCommand : IRequest
    {
        public MessageDto MessageDto { get; set; }
    }
}
