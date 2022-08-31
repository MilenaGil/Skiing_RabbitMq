using ConsumerApi2.Application.Dto;

namespace ConsumerApi2.Core.Repository
{
    public interface IConsumerRepository
    {
        Task CreateAsync(MessageDto NewRequest);
        Task<List<MessageDto>> GetAllAsync();
    }
}