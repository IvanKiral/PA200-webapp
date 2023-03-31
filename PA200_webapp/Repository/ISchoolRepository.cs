using PA200_webapp.models;

namespace PA200_webapp.Repository;

public interface ISchoolRepository: IRepositoryBase<School>
{

    public School createSchool(School newSchool);
}