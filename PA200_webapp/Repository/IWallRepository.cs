using PA200_webapp.models;

namespace PA200_webapp.Repository;

public interface IWallRepository: IRepositoryBase<Wall>
{
    public Wall GetWallForClass(string userEmail, int classId);
    public Wall GetWallForSubject(string userEmail, int classId);
}