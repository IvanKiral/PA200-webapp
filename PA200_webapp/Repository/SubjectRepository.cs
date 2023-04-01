using Microsoft.EntityFrameworkCore;
using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class SubjectRepository: RepositoryBase<Subject>, ISubjectRepository
{
    public SubjectRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }

    public Subject createSubject(Subject newSubject)
    {
        newSubject.Wall = new Wall();
        return SocialNetworkContext.Subjects.Add(newSubject).Entity;
    }

    public UserSubject AddUserToSubject(string userEmail, int subjectId, UserSubject userSubject)
    {
        var user = SocialNetworkContext.Users.FirstOrDefault(u => u.Email == userEmail);
        var subjectEntity = SocialNetworkContext.Subjects.FirstOrDefault(c => c.SubjectId == subjectId);
        userSubject.User = user;
        userSubject.Subject = subjectEntity;
        return SocialNetworkContext.UserSubjects.Add(userSubject).Entity;
    }

    public UserSubject AddStudentToSubject(int subjectId, UserSubject userSubject)
    {
        var subjectEntity = SocialNetworkContext.Subjects.FirstOrDefault(c => c.SubjectId == subjectId);
        userSubject.Subject = subjectEntity;
        return SocialNetworkContext.UserSubjects.Add(userSubject).Entity;
    }

    public Post CreatePost(string userEmail, int subjectId, Post post)
    {

        var userSubject = SocialNetworkContext.UserSubjects
            .Include("User")
            .FirstOrDefault(u => u.SubjectId == subjectId &&  u.User.Email == userEmail);
        post.Created = DateTime.Now.ToUniversalTime();
        
        if (userSubject == null || post.Created <= userSubject.From || post.Created >= userSubject.To)
        {
            throw new Exception("User is not registered in the subject");
        }
        
        
        var wall = SocialNetworkContext.Subjects
            .Include("Wall")
            .Include("Wall.Posts")
            .FirstOrDefault(s => s.SubjectId == subjectId)?
            .Wall;

        post.Wall = wall;
        post.User = userSubject.User;
        return SocialNetworkContext.Posts.Add(post).Entity;
    }
}