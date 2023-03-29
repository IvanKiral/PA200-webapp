using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class CommentRepository: RepositoryBase<Comment>, ICommentRepository
{
    public CommentRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }
}