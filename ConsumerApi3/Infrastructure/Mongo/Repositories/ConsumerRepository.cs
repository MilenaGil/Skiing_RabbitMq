using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ConsumerApi3.Application.Dto;
using ConsumerApi3.Core.Repository;
using ConsumerApi3.Infrastructure.Mongo.Document;

namespace ConsumerApi3.Infrastructure.Mongo.Repositories
{
    public class ConsumerRepository : IConsumerRepository
    {
        private readonly IMongoCollection<MessageDocument> _messageCollection;
        private readonly IMapper _mapper;

        public ConsumerRepository(IOptions<ConsumerDatabaseSettings> consumerDatabaseSettings, IMapper mapper)
        {
            var mongoClient = new MongoClient(consumerDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(consumerDatabaseSettings.Value.DatabaseName);
            _messageCollection = mongoDatabase.GetCollection<MessageDocument>(consumerDatabaseSettings.Value.Consumer3CollectionName);
            _mapper = mapper;
        }
        public async Task CreateAsync(MessageDto NewRequest) =>
            await _messageCollection.InsertOneAsync(_mapper.Map<MessageDocument>(NewRequest));

        public async Task<List<MessageDto>> GetAllAsync()
        {
            var responseDocumentList = await _messageCollection.FindAsync(_ => true);
            return responseDocumentList.ToEnumerable().Select(or => _mapper.Map<MessageDto>(or)).ToList();
        }
    }
}