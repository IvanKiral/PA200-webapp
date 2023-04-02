using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services;

public interface IClassService
{
    public AddTeacherToClassSubjectDTO AddTeacherToClass(string email, int classID, AddTeacherToClassSubjectDTO dto);
    public AddStudentToClassSubjectDTO AddStudentToClass(int classID, AddStudentToClassSubjectDTO subjectDto);

    public WallDTO GetClassWall(string userEmail, int id);
    
    public CreatePostResponseModel CreatePost(string userEmail, int classId, CreatePostDTO dto);
    
    public void DeletePost(string userEmail, int classId, int post);

    public UpdatePostResponseModel UpdatePost(string userEmail, int postId, UpdatePostDTO dto);
}