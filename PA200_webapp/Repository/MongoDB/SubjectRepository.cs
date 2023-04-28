using Microsoft.Extensions.Options;
using PA200_webapp.DB;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB;

public class SubjectRepository: BaseRepository<Subject>, Interfaces.ISubjectRepository
{
    public SubjectRepository(IOptions<MongoDBDatabase> databaseSettings) : base(databaseSettings)
    {
    }
    
}