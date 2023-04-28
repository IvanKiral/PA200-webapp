using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PA200_webapp.DB;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB;

public class SchoolRepository: BaseRepository<School>, Interfaces.ISchoolRepository
{
    private IMongoCollection<Post> postCollection;
    public SchoolRepository(IOptions<MongoDBDatabase> databaseSettings) : base(databaseSettings)
    {
        var db = new MongoClient(databaseSettings.Value.ConnectionString);
        postCollection = db.GetDatabase(databaseSettings.Value.DatabaseName).GetCollection<Post>(nameof(Post));
    }
    
    public Wall GetWall()
    {
        var school = Collection.FindSync(_ => true).ToEnumerable().First();
        return school.Wall;
    }

    public WallWithPosts GetWallWithPosts()
    {
        var school = Collection.Aggregate().Lookup<School, Post, School>(
            postCollection,
            s => s.Wall.Id,
            p => p.WallId,
            n => n.WallWithPosts.Posts
        ).First();

        return school.WallWithPosts;
    }
}