using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class SchoolRepository: RepositoryBase<School>, ISchoolRepository
{
    public SchoolRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }
}