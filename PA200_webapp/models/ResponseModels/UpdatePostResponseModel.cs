using MongoDB.Bson;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.models.ResponseModels;

public class UpdatePostResponseModel
{
    public string Text { get; set; }
    public ObjectId Id { get; set; }
}