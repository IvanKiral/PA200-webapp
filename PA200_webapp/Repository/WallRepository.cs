using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class WallRepository: RepositoryBase<Wall>, IWallRepository
{
    public WallRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }
}