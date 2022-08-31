﻿using AutoMapper;
using ConsumerApi2.Application.Dto;
using ConsumerApi2.Infrastructure.Mongo.Document;

namespace ConsumerApi2.Infrastructure.Mongo.Profiles
{
    public class MessageDtoToMessageDocument : Profile
    {
        public MessageDtoToMessageDocument()
        {
            CreateMap<MessageDto, MessageDocument>();
        }
    }
}
