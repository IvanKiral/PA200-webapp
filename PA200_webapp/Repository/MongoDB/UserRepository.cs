using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
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
        var user = Collection.FindSync(u => u.Email == userEmail).First();

        if (user.Attends.Select(a => a.AttendId).Contains(attends.AttendId))
        {
            throw new Exception("Given attendance already exists");
        }
        var updateDefinition = Builders<User>.Update.Push(u => u.Attends, attends);
        
        var filter = Builders<User>.Filter.Eq(u => u.Email, userEmail);

        Collection.UpdateOne(filter, updateDefinition);
        return attends;
    }
}