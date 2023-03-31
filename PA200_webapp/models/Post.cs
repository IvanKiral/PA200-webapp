using System.ComponentModel.DataAnnotations;

namespace PA200_webapp.models;

public enum PostType
{
    Post, Comment
}

public class Post
{
    [Key]
    public int PostId { get; set; }
    [Required]
    [StringLength(15000)]
    public string Text { get; set; }

    public bool IsDeleted { get; set; } = false;

    public PostType Type { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int WallId { get; set; }
    public Wall Wall { get; set; }
    
    public DateTime Created { get; set; }

    public int? ParentPostId { get; set; }
    public Post? ParentPost { get; set; }

    public IEnumerable<Post> Comments { get; set; }
}