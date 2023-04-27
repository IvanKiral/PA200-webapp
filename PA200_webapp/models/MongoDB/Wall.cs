using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PA200_webapp.models.MongoDB;

public class Wall: BaseDocument
{
    public IEnumerable<Post> Posts { get; set; }
}