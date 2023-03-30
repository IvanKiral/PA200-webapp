using System.ComponentModel.DataAnnotations;

namespace PA200_webapp.models;

public class Post
{
    [Key]
    public int PostId { get; set; }
    [Required]
    [StringLength(15000)]
    public string Text { get; set; }

    public bool IsDeleted { get; set; } = false;

    public int UserId { get; set; }
    public User User { get; set; }

    public int WallId { get; set; }
    public Wall Wall { get; set; }
    
    public DateTime Created { get; set; }

    public IEnumerable<Comment> Comments { get; set; }
}