using HotelsHubApp.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotelsHubApp.DataAccess.Concrete.MongoDB
{
    public abstract class MongoDbEntity : IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        [BsonElement(Order = 0)]
        public string Id { get; } = ObjectId.GenerateNewId().ToString();

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonElement(Order = 101)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
