using MongoDB.Bson;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.models.ResponseModels;

public class CreateUserResponseModel
{
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
}