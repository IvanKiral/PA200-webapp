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
}