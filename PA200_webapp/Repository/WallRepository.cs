using Microsoft.EntityFrameworkCore;
using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class WallRepository: RepositoryBase<Wall>, IWallRepository
{
    public WallRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }

    public Wall GetWallForClass(string userEmail, int classId)
    {
        var userClass = SocialNetworkContext.UserClasses
            .Include("User")
            .FirstOrDefault(u => u.ClassId == classId &&  u.User.Email == userEmail);

        var classWall = SocialNetworkContext.Walls.Include("Posts").Include("Class").Include("Posts.User")
            .FirstOrDefault(w => w.Class.ClassId == classId);

        classWall.Posts = classWall.Posts.Where(p => p.Created >= userClass.From && p.Created <= userClass.To).ToList();

        return classWall;
    }

    public Wall GetWallForSubject(string userEmail, int subjectId)
    {
        var userSubject = SocialNetworkContext.UserSubjects
            .Include("User")
            .FirstOrDefault(u => u.SubjectId == subjectId &&  u.User.Email == userEmail);

        var subjectWall = SocialNetworkContext.Walls.Include("Posts").Include("Subject").Include("Posts.User")
            .FirstOrDefault(w => w.Subject.SubjectId == subjectId);

        subjectWall.Posts = subjectWall.Posts.Where(p => p.Created >= userSubject.From && p.Created <= userSubject.To).ToList();

        return subjectWall;
    }
}