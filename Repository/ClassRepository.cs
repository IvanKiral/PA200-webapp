using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class ClassRepository: RepositoryBase<Class>, IClassRepository
{
    public ClassRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }
}