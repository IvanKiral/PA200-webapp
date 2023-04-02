using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services;

public interface ISubjectService
{
    public AddTeacherToClassSubjectDTO AddTeacherToSubject(string email, int subjectId, AddTeacherToClassSubjectDTO dto);
    public AddStudentToClassSubjectDTO AddStudentToSubject(int subjectId, AddStudentToClassSubjectDTO dto);
    
    public WallDTO GetSubjectWall(string userEmail, int id);

    public CreatePostResponseModel CreatePost(string userEmail, int subjectId, CreatePostDTO dto);

    public void DeletePost(string userEmail, int subjectId, int post);

    public UpdatePostResponseModel UpdatePost(string userEmail, int postId, UpdatePostDTO dto);
}