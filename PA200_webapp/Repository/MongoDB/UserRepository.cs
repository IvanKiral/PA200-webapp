using AutoMapper;
using Microsoft.Extensions.Options;
using PA200_webapp.DB;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB;

public class UserRepository: BaseRepository<User>, Interfaces.IUserRepository
{
    public UserRepository(IOptions<MongoDBDatabase> databaseSettings) : base( databaseSettings)
    {
    }

    public User GetUserByEmail(string userEmail) =>  FilterBy(u => u.Email == userEmail).First();

    public Attends AddUserAttends(string userEmail, Attends attends)
    {
        var updateDefinition = global::MongoDB.Driver.Builders<User>.Update.Push(u => u.Attends, attends);
        
        var filter = global::MongoDB.Driver.Builders<User>.Filter.Eq(u => u.Email, userEmail);

        Collection.UpdateOneAsync(filter, updateDefinition);
        return attends;
    }
}