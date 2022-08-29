using MediatR;
using Microsoft.AspNetCore.Mvc;
using Publisher.Application.Commands;
using Publisher.Application.Dto;
using Publisher.Application.Queries;
using Publisher.Infrastructure.Repositories;

namespace Publisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly RabbitMQPublisherRepository _messageProducer;
        private readonly IMediator _mediator;
        public PublisherController(RabbitMQPublisherRepository messageProducer, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<MessageDto>>> GetAllMessagesAsync()
        {
            var getMessageQuery = new GetMessageQuery();
            var queryResponse = await _mediator.Send(getMessageQuery);
            return Ok(queryResponse);
        }

        [HttpPost("PublishRequest")]
        public async Task<ActionResult> CreateAsync([FromBody] MessageDto message)
        {
            var createMessageCommand = new CreateMessageCommand { MessageDto = message };
            await _mediator.Send(createMessageCommand);
            var returndata = new { createMessageCommand.MessageDto };
            var sendMessageCommand = new SendMessageCommand { MessageDto = message };
            await _mediator.Send(sendMessageCommand);
            return Created("", returndata);
        }
    }
}
