using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class SchoolRepository: RepositoryBase<School>, ISchoolRepository
{
    public SchoolRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }

    public School createSchool(School newSchool)
    {
        newSchool.Wall = new Wall();
        var entity = SocialNetworkContext.Schools.Add(newSchool);
        return entity.Entity;
    }
}