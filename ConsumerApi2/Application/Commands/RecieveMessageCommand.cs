using MediatR;
using ConsumerApi2.Application.Dto;

namespace ConsumerApi2.Application.Commands
{
    public class RecieveMessageCommand : IRequest
    {
        public MessageDto MessageDto { get; set; }
    }
}
