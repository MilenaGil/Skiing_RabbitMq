using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Publisher.Application.Dto;
using Publisher.Core.Repository;
using Publisher.Infrastructure.Mongo.Document;

namespace Publisher.Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly IMongoCollection<MessageDocument> _messageCollection;
        private readonly IMapper _mapper;

        public PublisherRepository(IOptions<PublisherDatabaseSettings> publisherDatabaseSettings, IMapper mapper)
        {
            var mongoClient = new MongoClient(publisherDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(publisherDatabaseSettings.Value.DatabaseName);
            _messageCollection = mongoDatabase.GetCollection<MessageDocument>(publisherDatabaseSettings.Value.PublisherCollectionName);
            _mapper = mapper;
        }
        public async Task CreateAsync(MessageDto NewRequest) =>
            await _messageCollection.InsertOneAsync(_mapper.Map<MessageDocument>(NewRequest));

        public async Task<List<MessageDto>> GetAllAsync()
        {
            return (await GetAsync()).Select(or => _mapper.Map<MessageDto>(or)).ToList();
        }

        public async Task<List<MessageDocument>> GetAsync() =>
            await _messageCollection.Find(_ => true).ToListAsync();
    }
}
