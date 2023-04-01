using PA200_webapp.models;
using PA200_webapp.models.DTO;

namespace PA200_webapp.Repository;

public interface IPostRepository: IRepositoryBase<Post>
{
    public Post CreatePostOnSchoolWall(string userEmail, Post post);

}