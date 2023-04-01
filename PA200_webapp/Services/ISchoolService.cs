using PA200_webapp.models.DTO;

namespace PA200_webapp.Services;

public interface ISchoolService
{
    public SchoolWallDTO GetSchoolWall(string userEmail);

    public CreatePostOnSchoolWallDTO CreatePost(string userEmail, CreatePostOnSchoolWallDTO dto);

}