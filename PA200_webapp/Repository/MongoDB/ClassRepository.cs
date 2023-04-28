using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PA200_webapp.DB;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB;

public class ClassRepository: BaseRepository<Class>, Interfaces.IClassRepository
{
    public ClassRepository(IOptions<MongoDBDatabase> databaseSettings) : base(databaseSettings)
    {
    }
}