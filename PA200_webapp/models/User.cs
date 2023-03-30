using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA200_webapp.models;

public enum UserRole
{
    Student,
    Teacher
}

public class User
{
    [Key]
    public int UserId { get; set; }
    [StringLength(32)]
    [Required]
    public string Name { get; set; }
    [StringLength(64)]
    [Required]
    public string Lastname { get; set; }
    [StringLength(128)]
    [Required]
    public string Email { get; set; }
    [Required]
    public string PasswordHash { get; set; }
    [Required]
    public UserRole Role { get; set; }
    
    public IEnumerable<Like> Likes { get; set; }
    
    public IEnumerable<Post> Posts { get; set; }

    public IEnumerable<UserClass> UserClasses { get; set; }
    
    public IEnumerable<UserSubject> UserSubjects { get; set; }
}