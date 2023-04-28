using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB.Interfaces;

public interface ISchoolRepository: IBaseRepository<School>
{
    public Wall GetWall();

    public WallWithPosts GetWallWithPosts();
}