using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services;

public interface ISchoolService
{
    public WallDTO GetSchoolWall(string userEmail);

    public CreatePostResponseModel CreatePost(string userEmail, CreatePostDTO dto);
    
}