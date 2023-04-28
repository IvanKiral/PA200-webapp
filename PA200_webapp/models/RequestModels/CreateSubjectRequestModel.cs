using MongoDB.Bson;

namespace PA200_webapp.models.RequestModels;

public class CreateSubjectRequestModel
{
    public string ClassId { get; set; }
    public string Name { get; set; }
}