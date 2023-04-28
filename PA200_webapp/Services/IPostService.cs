using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services;

public interface IPostService
{
    public void LikePost(string userEmail, string postId);
    
    public void DeleteLike(string userEmail, string postId);

    public CreatePostResponseModel CreateComment(string userEmail, string parentPostId, CreatePostDTO dto);

    public WallPost GetPost(string postId);
    
    public void DeletePost(string userEmail, string postId);
    public UpdatePostResponseModel UpdatePost(string userEmail, string postId, UpdatePostDTO dto);
}