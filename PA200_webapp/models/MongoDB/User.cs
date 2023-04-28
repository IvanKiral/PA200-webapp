using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PA200_webapp.models.MongoDB;

public enum AttendType
{
    Subject,
    Class
}
public class Attends
{
    public ObjectId AttendId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public AttendType Type { get; set; }
}

public class User: BaseDocument
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
    public IEnumerable<Attends> Attends { get; set; } = new List<Attends>();
}