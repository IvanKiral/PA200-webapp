using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services.MongoDB;

public class SubjectService: ISubjectService
{
    public AddTeacherToClassSubjectDTO AddTeacherToSubject(string email, int subjectId, AddTeacherToClassSubjectDTO dto)
    {
        throw new NotImplementedException();
    }

    public AddStudentToClassSubjectDTO AddStudentToSubject(int subjectId, AddStudentToClassSubjectDTO dto)
    {
        throw new NotImplementedException();
    }

    public WallDTO GetSubjectWall(string userEmail, int id)
    {
        throw new NotImplementedException();
    }

    public CreatePostResponseModel CreatePost(string userEmail, int subjectId, CreatePostDTO dto)
    {
        throw new NotImplementedException();
    }

    public void DeletePost(string userEmail, int subjectId, int post)
    {
        throw new NotImplementedException();
    }

    public UpdatePostResponseModel UpdatePost(string userEmail, int postId, UpdatePostDTO dto)
    {
        throw new NotImplementedException();
    }
}