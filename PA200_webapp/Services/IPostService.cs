using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services;

public interface IPostService
{
    public void LikePost(string userEmail, int postId);
    
    public void DeleteLike(string userEmail, int postId);

    public CreatePostResponseModel CreateComment(string userEmail, int parentPostId, CreatePostDTO dto);

    public WallPost GetPost(int postId);
}