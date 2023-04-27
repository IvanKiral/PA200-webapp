using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PA200_webapp.models.MongoDB;

public class Post: BaseDocument
{
    public string Text { get; set; }
    public bool IsDeleted { get; set; } = false;
    public PostType Type { get; set; }
    public DateTime Created { get; set; }
    public ObjectId AuthorId { get; set; }
    public IEnumerable<Post> Comments { get; set; }
    public IEnumerable<ObjectId> Likes { get; set; }
}