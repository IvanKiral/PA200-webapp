using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA200_webapp.models;

public class Like
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    
    public User User { get; set; }

    
    public Post Post { get; set; }
}