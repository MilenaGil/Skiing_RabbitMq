using AutoMapper;
using ConsumerApi3.Application.Dto;
using ConsumerApi3.Infrastructure.Mongo.Document;

namespace ConsumerApi3.Infrastructure.Mongo.Profiles
{
    public class MessageDtoToMessageDocument : Profile
    {
        public MessageDtoToMessageDocument()
        {
            CreateMap<MessageDto, MessageDocument>();
        }
    }
}
