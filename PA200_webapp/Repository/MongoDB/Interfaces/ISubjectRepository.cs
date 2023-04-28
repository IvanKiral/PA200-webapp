using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB.Interfaces;

public interface ISubjectRepository: IBaseRepository<Subject>
{
    public Wall GetWall(string subjectId);
    
    public WallWithPosts GetWallWithPosts(string subjectId);
}