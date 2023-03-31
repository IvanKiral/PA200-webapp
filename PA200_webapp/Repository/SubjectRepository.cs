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
}