using MongoDB.Bson;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.models.ResponseModels;

public class CreatePostResponseModel
{
    public ObjectId Id { get; set; }
    public string Text { get; set; }
    public PostAuthor PostAuthor { get; set; }
    public PostType Type { get; set; }
}