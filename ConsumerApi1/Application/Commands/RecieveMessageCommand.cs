using MediatR;
using ConsumerApi1.Application.Dto;

namespace ConsumerApi1.Application.Commands
{
    public class RecieveMessageCommand : IRequest
    {
        public MessageDto MessageDto { get; set; }
    }
}
