using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PA200_webapp.DB;
using PA200_webapp.models.DTO;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB;

public class PostRepository: BaseRepository<Post>, Interfaces.IPostRepository
{
    public PostRepository(IOptions<MongoDBDatabase> databaseSettings) : base(databaseSettings)
    {
    }

    public void CreateLike(string postId, ObjectId userId)
    {
        
        var filter = Builders<Post>.Filter.Eq(p => p.Id, ObjectId.Parse(postId));
        var update = Builders<Post>.Update.Push(p => p.Likes, userId);

        Collection.UpdateOne(filter, update);
    }

    public void DeleteLike(string postId, ObjectId userId)
    {
        var filter = Builders<Post>.Filter.Eq(p => p.Id, ObjectId.Parse(postId));
        var update = Builders<Post>.Update.Pull(p => p.Likes, userId);

        Collection.UpdateOne(filter, update);
    }

    public Comment CreateComment(string postId, CreateCommentDTO dto)
    {
        var filter = Builders<Post>.Filter.Eq(p => p.Id, ObjectId.Parse(postId));

        var newComment = new Comment()
        {
            Id = ObjectId.GenerateNewId(),
            Text = dto.Text,
            Author = dto.Author
        };

        var update = Builders<Post>.Update.Push(p => p.Comments, newComment);

        Collection.UpdateOne(filter, update);
        return newComment;
    }

    public void DeletePost(string postId)
    {
        var filter = Builders<Post>.Filter.Eq(p => p.Id, ObjectId.Parse(postId));
        var update = Builders<Post>.Update.Set(p => p.IsDeleted, true);
        
        Collection.UpdateOne(filter, update);
    }

    public Post UpdatePostText(string postId, string Text)
    {
        var filter = Builders<Post>.Filter.Eq(p => p.Id, ObjectId.Parse(postId));
        var update = Builders<Post>.Update.Set(p => p.Text, Text);

        Collection.UpdateOne(filter, update);

        return Collection.FindSync(p => ObjectId.Parse(postId) == p.Id).First();
    }
}