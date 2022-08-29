using AutoMapper;
using Publisher.Application.Dto;
using Publisher.Infrastructure.Mongo.Document;

namespace Publisher.Infrastructure.Mongo.Profiles
{
    public class MessageDtoToMessageDocument : Profile
    {
        public MessageDtoToMessageDocument()
        {
            CreateMap<MessageDto, MessageDocument>();
        }
    }
}
