using Microsoft.EntityFrameworkCore;
using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class ClassRepository: RepositoryBase<Class>, IClassRepository
{
    public ClassRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }

    public Class createClass(Class newClass)
    {
        newClass.Wall = new Wall();
        return SocialNetworkContext.Classes.Add(newClass).Entity;
    }

    public UserClass AddUserToClass(string userEmail, int classId, UserClass userClass)
    {
        var user = SocialNetworkContext.Users.FirstOrDefault(u => u.Email == userEmail);
        var classEntity = SocialNetworkContext.Classes.FirstOrDefault(c => c.ClassId == classId);
        userClass.User = user;
        userClass.Class = classEntity;
        return SocialNetworkContext.UserClasses.Add(userClass).Entity;
    }

    public UserClass AddStudentToClass(int classId, UserClass userClass)
    {
        var classEntity = SocialNetworkContext.Classes.FirstOrDefault(c => c.ClassId == classId);
        userClass.Class = classEntity;
        return SocialNetworkContext.UserClasses.Add(userClass).Entity;
    }

    public Post CreatePost(string userEmail, int classId, Post post)
    {
        var userClass = SocialNetworkContext.UserClasses
            .Include("User")
            .FirstOrDefault(u => u.ClassId == classId &&  u.User.Email == userEmail);
        post.Created = DateTime.Now.ToUniversalTime();
        
        if (userClass == null || post.Created <= userClass.From || post.Created >= userClass.To)
        {
            throw new Exception("User is not registered in the subject");
        }
        
        
        var wall = SocialNetworkContext.Classes
            .Include("Wall")
            .Include("Wall.Posts")
            .FirstOrDefault(s => s.ClassId == classId)?
            .Wall;

        post.Wall = wall;
        post.User = userClass.User;
        return SocialNetworkContext.Posts.Add(post).Entity;
    }
}