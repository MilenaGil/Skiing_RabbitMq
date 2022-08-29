using Publisher.Application.Dto;
using Publisher.Infrastructure.Mongo.Document;

namespace Publisher.Core.Repository
{
    public interface IPublisherRepository
    {
        Task CreateAsync(MessageDto NewRequest);
        Task<List<MessageDocument>> GetAsync();
        Task<List<MessageDto>> GetAllAsync();
    }
}
