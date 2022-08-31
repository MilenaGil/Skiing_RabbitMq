using ConsumerApi3.Application.Dto;

namespace ConsumerApi3.Core.Repository
{
    public interface IConsumerRepository
    {
        Task CreateAsync(MessageDto NewRequest);
        Task<List<MessageDto>> GetAllAsync();
    }
}