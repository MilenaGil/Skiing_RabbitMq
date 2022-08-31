using AutoMapper;
using ConsumerApi4.Application.Dto;
using ConsumerApi4.Infrastructure.Mongo.Document;

namespace ConsumerApi4.Infrastructure.Mongo.Profiles
{
    public class MessageDocumentToMessageDto : Profile
    {
        public MessageDocumentToMessageDto()
        {
            CreateMap<MessageDocument, MessageDto>();
        }
    }
}
