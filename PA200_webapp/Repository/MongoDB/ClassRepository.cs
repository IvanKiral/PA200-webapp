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

    public Subject CreateSubject(ObjectId classId, Subject newSubject)
    {
        newSubject.Id = ObjectId.GenerateNewId();
        var updateDefinition = Builders<Class>.Update.Push(c => c.Subjects, newSubject);
        
        var filter = Builders<Class>.Filter.Eq(c => c.Id, classId);

        Collection.UpdateOneAsync(filter, updateDefinition);

        return newSubject;
    }

    public IEnumerable<Subject> GetAllSubjects()
    {
        return GetAll().SelectMany(c => c.Subjects);
    }
}