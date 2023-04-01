using PA200_webapp.models.DTO;

namespace PA200_webapp.Services;

public interface ISchoolService
{
    public WallDTO GetSchoolWall(string userEmail);

    public CreatePostDTO CreatePost(string userEmail, CreatePostDTO dto);
    
}