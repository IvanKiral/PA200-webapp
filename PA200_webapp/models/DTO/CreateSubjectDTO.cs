using MongoDB.Bson;

namespace PA200_webapp.models.DTO;

public class CreateSubjectDTO
{
    public ObjectId ClassId { get; set; }
    public string Name { get; set; }
}