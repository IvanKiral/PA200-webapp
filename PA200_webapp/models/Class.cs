using System.ComponentModel.DataAnnotations;

namespace PA200_webapp.models;

public class Class
{
    [Key]
    public int ClassId { get; set; }
    
    [StringLength(128)]
    [Required]
    public string Name { get; set; }
    
    public Wall Wall { get; set; }
    
    public IEnumerable<UserClass> UserClasses { get; set; }

}