using MediatR;
using ConsumerApi3.Application.Dto;

namespace ConsumerApi3.Application.Commands
{
    public class RecieveMessageCommand : IRequest
    {
        public MessageDto MessageDto { get; set; }
    }
}
