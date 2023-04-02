using Microsoft.EntityFrameworkCore;
using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }

    public User? GetUserWithSchool(string email)
    {
        return SocialNetworkContext.Users
            .Include("School")
            .Include("School.Wall")
            .Include("School.Wall.Posts")
            .Include("School.Wall.Posts.User")
            .Include("School.Wall.Posts.Likes")
            .Include("School.Wall.Posts.Comments")
            .FirstOrDefault(u => u.Email == email);
    }

    public User GetUserWithUserSubject(string email)
    {
        return SocialNetworkContext.Users.Include("UserSubjects").FirstOrDefault(u => u.Email == email);
    }

    public User GetUserWithUserClass(string email)
    {
        return SocialNetworkContext.Users.Include("UserClasses").FirstOrDefault(u => u.Email == email);
    }

    public Wall GetUserWall(string email)
    {
        var user = SocialNetworkContext.Users
            .Include("School.Wall.Posts.Likes")
            .Include("School.Wall.Posts.Comments")
            .Include("School.Wall.Posts.User")
            .Include("UserSubjects.Subject.Wall.Posts.User")
            .Include("UserSubjects.Subject.Wall.Posts.Likes")
            .Include("UserSubjects.Subject.Wall.Posts.Comments")
            .Include("UserClasses.Class.Wall.Posts.Likes")
            .Include("UserClasses.Class.Wall.Posts.Comments")
            .Include("UserClasses.Class.Wall.Posts.User")
            .FirstOrDefault(u => u.Email == email);

        var posts = user.School.Wall.Posts
            .Concat(user.UserClasses.SelectMany(c => c.Class.Wall.Posts))
            .Concat(user.UserSubjects.SelectMany(c => c.Subject.Wall.Posts));

        posts = posts
            .Where(p => !p.IsDeleted)
            .Select(p =>
            {
                p.Comments = p.Comments.Take(1);
                return p;
            });

        return new Wall()
        {
            Posts = posts
        };
    }
}