using ConsumerApi1.Application.Dto;

namespace ConsumerApi1.Core.Repository
{
    public interface IConsumerRepository
    {
        Task CreateAsync(MessageDto NewRequest);
        Task<List<MessageDto>> GetAllAsync();
    }
}