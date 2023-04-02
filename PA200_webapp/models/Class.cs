using System.ComponentModel.DataAnnotations;

namespace PA200_webapp.models;

public class Class
{
    [Key]
    public int ClassId { get; set; }
    
    [StringLength(128)]
    [Required]
    public string Name { get; set; }

    public int WallId { get; set; }
    public Wall Wall { get; set; }

    public int SchoolId { get; set; }
    public School School { get; set; }
    
    public IEnumerable<UserClass> UserClasses { get; set; }
    
    public IEnumerable<Subject> Subjects { get; set; }
}