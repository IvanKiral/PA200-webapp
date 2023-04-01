using PA200_webapp.models;

namespace PA200_webapp.Repository;

public interface ISubjectRepository: IRepositoryBase<Subject>
{
    public Subject createSubject(Subject newSubject);
    
    public UserSubject AddUserToSubject(string userEmail, int subjectId, UserSubject userSubject);

    public UserSubject AddStudentToSubject(int classId, UserSubject userSubject);
}