using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services.MongoDB;

public class ClassService: IClassService
{
    public AddTeacherToClassSubjectDTO AddTeacherToClass(string email, int classID, AddTeacherToClassSubjectDTO dto)
    {
        throw new NotImplementedException();
    }

    public AddStudentToClassSubjectDTO AddStudentToClass(int classID, AddStudentToClassSubjectDTO subjectDto)
    {
        throw new NotImplementedException();
    }

    public WallDTO GetClassWall(string userEmail, int id)
    {
        throw new NotImplementedException();
    }

    public CreatePostResponseModel CreatePost(string userEmail, int classId, CreatePostDTO dto)
    {
        throw new NotImplementedException();
    }

    public void DeletePost(string userEmail, int classId, int post)
    {
        throw new NotImplementedException();
    }

    public UpdatePostResponseModel UpdatePost(string userEmail, int postId, UpdatePostDTO dto)
    {
        throw new NotImplementedException();
    }
}