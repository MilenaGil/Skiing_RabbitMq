using MediatR;
using ConsumerApi4.Application.Dto;

namespace ConsumerApi4.Application.Commands
{
    public class RecieveMessageCommand : IRequest
    {
        public MessageDto MessageDto { get; set; }
    }
}
