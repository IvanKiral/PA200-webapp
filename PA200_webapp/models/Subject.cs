using System.ComponentModel.DataAnnotations;

namespace PA200_webapp.models;

public class Subject
{
    [Key]
    public int SubjectId { get; set; }
    
    [StringLength(128)]
    [Required]
    public string Name { get; set; }
    
    public int WallId { get; set; }
    public Wall Wall { get; set; }

    public int ClassId { get; set; }
    public Class Class { get; set; }
    
    public IEnumerable<UserSubject> UserSubjects { get; set; }
}