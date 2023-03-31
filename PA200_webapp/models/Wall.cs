using System.ComponentModel.DataAnnotations;

namespace PA200_webapp.models;

public class Wall
{
    [Key]
    public int WallId { get; set; }

    public IEnumerable<Post> Posts { get; set; }
    
    public Class? Class { get; set; }
    
    public Subject? Subject { get; set; }

    public School? School { get; set; }
}