using System.ComponentModel.DataAnnotations;

namespace PA200_webapp.models;

public class Comment
{
    [Key]
    public int CommentId { get; set; }
    
    [Required]
    [StringLength(3000)]
    public string Text { get; set; }
    
}