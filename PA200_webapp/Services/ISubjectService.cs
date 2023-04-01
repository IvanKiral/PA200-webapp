using PA200_webapp.models.DTO;

namespace PA200_webapp.Services;

public interface ISubjectService
{
    public AddTeacherToClassSubjectDTO AddTeacherToSubject(string email, int subjectId, AddTeacherToClassSubjectDTO dto);
    public AddStudentToClassSubjectDTO AddStudentToSubject(int subjectId, AddStudentToClassSubjectDTO dto);
    
    public WallDTO GetSubjectWall(string userEmail, int id);

    public CreatePostDTO CreatePost(string userEmail, int subjectId, CreatePostDTO dto);
}