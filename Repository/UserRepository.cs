using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class UserRepository: RepositoryBase<User>, IUserRepository
{
    public UserRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }
}