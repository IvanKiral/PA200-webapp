using PA200_webapp.models;

namespace PA200_webapp.Repository;

public interface ISubjectRepository: IRepositoryBase<Subject>
{
    public Subject createSubject(Subject newSubject);
}