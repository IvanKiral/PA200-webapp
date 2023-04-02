using Microsoft.EntityFrameworkCore;
using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class PostRepository: RepositoryBase<Post>, IPostRepository
{
    public PostRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }

    public Post CreatePostOnSchoolWall(string userEmail, Post post)
    {
        var user = SocialNetworkContext.Users.Include("School").Include("School.Wall").FirstOrDefault(u => u.Email == userEmail);
        post.User = user;
        post.Wall = user.School.Wall;
        post.Created = DateTime.UtcNow;
        return SocialNetworkContext.Add(post).Entity;
    }

    public Post GetPostWithUser(int post)
    {
        return SocialNetworkContext.Posts
            .Include("User")
            .Include("Wall")
            .Include("Wall.Subject")
            .Include("Wall.Class")
            .FirstOrDefault(p => p.PostId == post);
    }
    
    public Post GetPostWithCommentsLikesWall(int post)
    {
        return SocialNetworkContext.Posts
            .Include("Wall")
            .Include("Comments")
            .Include("Likes")
            .Include("User")
            .FirstOrDefault(p => p.PostId == post);
    }

    public Post CreateComment(Post newComment)
    {
        return SocialNetworkContext.Posts.Add(newComment).Entity;
    }
}