using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PA200_webapp.DB;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB;

public class ClassRepository: BaseRepository<Class>, Interfaces.IClassRepository
{
    private IMongoCollection<Post> postCollection;
    public ClassRepository(IOptions<MongoDBDatabase> databaseSettings) : base(databaseSettings)
    {
        var db = new MongoClient(databaseSettings.Value.ConnectionString);
        postCollection = db.GetDatabase(databaseSettings.Value.DatabaseName).GetCollection<Post>(nameof(Post));
    }

    public Wall GetWall(string classId)
    {
        var classEntity = Collection.FindSync(c => c.Id == ObjectId.Parse(classId)).ToEnumerable().First();
        return classEntity.Wall;
    }

    public WallWithPosts GetWallWithPosts(string classId)
    {
        var filter = Builders<Class>.Filter.Eq(c => c.Id, ObjectId.Parse(classId));
        var classEntity = Collection.Aggregate().Match(filter).Lookup<Class, Post, Class>(
            postCollection,
            s => s.Wall.Id,
            p => p.WallId,
            n => n.WallWithPosts.Posts
        ).FirstOrDefault();

        if (classEntity == null)
        {
            throw new Exception("No class with that ID");
        }

        return classEntity.WallWithPosts;
    }
}