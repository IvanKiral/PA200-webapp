using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class PostRepository: RepositoryBase<Post>, IPostRepository
{
    public PostRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }
}