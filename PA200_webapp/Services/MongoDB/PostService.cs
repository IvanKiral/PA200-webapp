using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services.MongoDB;

public class PostService: IPostService
{
    public void LikePost(string userEmail, int postId)
    {
        throw new NotImplementedException();
    }

    public void DeleteLike(string userEmail, int postId)
    {
        throw new NotImplementedException();
    }

    public CreatePostResponseModel CreateComment(string userEmail, int parentPostId, CreatePostDTO dto)
    {
        throw new NotImplementedException();
    }

    public WallPost GetPost(int postId)
    {
        throw new NotImplementedException();
    }
}