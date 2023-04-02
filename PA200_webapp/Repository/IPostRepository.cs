using PA200_webapp.models;
using PA200_webapp.models.DTO;

namespace PA200_webapp.Repository;

public interface IPostRepository: IRepositoryBase<Post>
{
    public Post CreatePostOnSchoolWall(string userEmail, Post post);

    public Post GetPostWithUser(int post);

    public Post GetPostWithCommentsLikesWall(int post);

    public Post CreateComment(Post newComment);
    
}