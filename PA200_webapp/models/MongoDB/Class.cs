using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PA200_webapp.models.MongoDB;

public class Class: BaseDocument
{
    public string Name { get; set; }
    public Wall Wall { get; set; } = new Wall();
    public IEnumerable<Subject> Subjects { get; set; } = new List<Subject>();
}