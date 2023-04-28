using MongoDB.Bson;

namespace PA200_webapp.models.DTO.Create;

public class ClassCreatedDto
{
    public ObjectId Id { get; set; }
    public string Name { get; set; }
}