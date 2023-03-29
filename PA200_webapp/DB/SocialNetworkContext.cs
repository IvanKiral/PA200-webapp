using Microsoft.EntityFrameworkCore;
using PA200_webapp.models;

namespace PA200_webapp.DB;

public class SocialNetworkContext : DbContext
{
    public SocialNetworkContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Wall> Walls { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<UserSubject> UserSubjects { get; set; }
    public DbSet<UserClass> UserClasses { get; set; }
    public DbSet<Like> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Like>()
            .HasKey(l => new { l.UserId, l.PostId });
    }
}