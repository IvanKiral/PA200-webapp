using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class LikeRepository: RepositoryBase<Like>, ILikeRepository
{
    public LikeRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }
}