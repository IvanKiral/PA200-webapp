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
}