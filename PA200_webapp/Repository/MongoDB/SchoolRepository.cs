using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PA200_webapp.DB;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB;

public class SchoolRepository: BaseRepository<School>, Interfaces.ISchoolRepository
{
    public SchoolRepository(IOptions<MongoDBDatabase> databaseSettings) : base(databaseSettings)
    {
    }


    public Wall GetWall()
    {
        var school = Collection.FindSync(_ => true).ToEnumerable().First();
        return school.Wall;
    }

    public Post CreatePostOnWall(Post newPost)
    {
        newPost.Id = ObjectId.GenerateNewId();
        
        var updateDefinition = Builders<School>.Update.Push(s => s.Wall.Posts, newPost);

        var filter = Builders<School>.Filter.Empty;

        Collection.UpdateOne(filter, updateDefinition);
        return newPost;
    }
}