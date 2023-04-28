using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services;

public interface IClassService
{
    public AddTeacherToClassSubjectDTO AddTeacherToClass(string email, string classID, AddTeacherToClassSubjectDTO dto);
    public AddStudentToClassSubjectDTO AddStudentToClass(string classID, AddStudentToClassSubjectDTO subjectDto);

    public WallResponseModel GetClassWall(string userEmail, string id);
    
    public CreatePostResponseModel CreatePost(string userEmail, string classId, CreatePostDTO dto);
    
    // public void DeletePost(string userEmail, string postId);
    //
    // public UpdatePostResponseModel UpdatePost(string userEmail, string postId, UpdatePostDTO dto);
}