using System.ComponentModel.DataAnnotations;

namespace PA200_webapp.models;

public class School
{
    [Key]
    public int SchoolId { get; set; }
    
    [StringLength(128)]
    [Required]
    public string Name { get; set; }
    
    public int WallId { get; set; }
    public Wall Wall { get; set; }
    
    public IEnumerable<Class> Classes { get; set; }

}