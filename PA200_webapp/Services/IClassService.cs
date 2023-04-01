using PA200_webapp.models;
using PA200_webapp.models.DTO;

namespace PA200_webapp.Services;

public interface IClassService
{
    public AddTeacherToClassSubjectDTO AddTeacherToClass(string email, int classID, AddTeacherToClassSubjectDTO dto);
    public AddStudentToClassSubjectDTO AddStudentToClass(int classID, AddStudentToClassSubjectDTO subjectDto);

    public WallDTO GetClassWall(string userEmail, int id);
    
    public CreatePostDTO CreatePost(string userEmail, int classId, CreatePostDTO dto);
}