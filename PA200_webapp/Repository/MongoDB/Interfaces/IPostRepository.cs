using MongoDB.Bson;
using PA200_webapp.models.DTO;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB.Interfaces;

public interface IPostRepository: IBaseRepository<Post>
{
    public void CreateLike(string postId, ObjectId userId);
    public void DeleteLike(string postId, ObjectId userId);

    public Comment CreateComment(string postId, CreateCommentDTO dto);

    public void DeletePost(string postId);

    public Post UpdatePostText(string postId, string Text);
}