using AutoMapper;
using Publisher.Application.Dto;
using Publisher.Infrastructure.Mongo.Document;

namespace Publisher.Infrastructure.Mongo.Profiles
{
    public class MessageDocumentToMessageDto : Profile
    {
        public MessageDocumentToMessageDto()
        {
            CreateMap<MessageDocument, MessageDto>();
        }
    }
}
