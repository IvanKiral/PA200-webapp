using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PA200_webapp.models.MongoDB;

public class BaseDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
}