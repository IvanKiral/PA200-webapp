using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PA200_webapp.DB;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB;

public class SubjectRepository: BaseRepository<Subject>, Interfaces.ISubjectRepository
{
    private IMongoCollection<Post> postCollection;
    public SubjectRepository(IOptions<MongoDBDatabase> databaseSettings) : base(databaseSettings)
    {
        var db = new MongoClient(databaseSettings.Value.ConnectionString);
        postCollection = db.GetDatabase(databaseSettings.Value.DatabaseName).GetCollection<Post>(nameof(Post));
    }

    public Wall GetWall(string subjectId)
    {
        var school = Collection.FindSync(_ => true).ToEnumerable().First();
        return school.Wall;
    }

    public WallWithPosts GetWallWithPosts(string subjectId)
    {
        var filter = Builders<Subject>.Filter.Eq(c => c.Id, ObjectId.Parse(subjectId));
        var subject = Collection.Aggregate().Match(filter).Lookup<Subject, Post, Subject>(
            postCollection,
            s => s.Wall.Id,
            p => p.WallId,
            n => n.WallWithPosts.Posts
        ).First();

        return subject.WallWithPosts;
    }
}