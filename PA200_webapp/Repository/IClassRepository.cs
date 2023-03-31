using PA200_webapp.models;
using PA200_webapp.models.RequestModels;

namespace PA200_webapp.Repository;

public interface IClassRepository: IRepositoryBase<Class>
{
    public Class createClass(Class newClass);

}