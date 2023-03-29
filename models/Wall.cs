using System.ComponentModel.DataAnnotations;

namespace PA200_webapp.models;

public class Wall
{
    [Key]
    public int WallId { get; set; }

    public IEnumerable<Post> Posts { get; set; }

    public int? ClassId { get; set; }
    public Class Class { get; set; }

    public int? SubjectId { get; set; }
    public Subject Subject { get; set; }
}