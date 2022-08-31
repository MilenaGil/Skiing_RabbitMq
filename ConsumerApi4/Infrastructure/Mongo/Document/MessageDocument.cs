using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsumerApi4.Infrastructure.Mongo.Document
{
    public class MessageDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int SkiId { get; set; }
        public string SkiProductNo { get; set; }
        public int PriceInPLN { get; set; }
        public int SkiLengthInCm { get; set; }
        public string SkiProducent { get; set; }
    }
}
