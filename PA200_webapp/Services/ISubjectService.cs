using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services;

public interface ISubjectService
{
    public AddTeacherToClassSubjectDTO AddTeacherToSubject(string email, string subjectId, AddTeacherToClassSubjectDTO dto);
    public AddStudentToClassSubjectDTO AddStudentToSubject(string subjectId, AddStudentToClassSubjectDTO dto);
    
    public WallResponseModel GetSubjectWall(string userEmail, string id);

    public CreatePostResponseModel CreatePost(string userEmail, string subjectId, CreatePostDTO dto);
}