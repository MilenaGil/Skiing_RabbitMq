using ConsumerApi4.Application.Dto;

namespace ConsumerApi4.Core.Repository
{
    public interface IConsumerRepository
    {
        Task CreateAsync(MessageDto NewRequest);
        Task<List<MessageDto>> GetAllAsync();
    }
}