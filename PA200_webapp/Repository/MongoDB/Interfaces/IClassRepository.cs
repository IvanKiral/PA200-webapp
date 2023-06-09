using MongoDB.Bson;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB.Interfaces;

public interface IClassRepository: IBaseRepository<models.MongoDB.Class>
{
    public Wall GetWall(string classId);
    
    public WallWithPosts GetWallWithPosts(string classId);
}