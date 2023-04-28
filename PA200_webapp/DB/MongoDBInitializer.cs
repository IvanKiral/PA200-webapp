using MongoDB.Driver;
using PA200_webapp.Infrastructure;
using PA200_webapp.models;
using PA200_webapp.Utils;
using User = PA200_webapp.models.MongoDB.User;

namespace PA200_webapp.DB;

public class MongoDBInitializer
{
    public static void Initliaze(IMongoDatabase mongoDbDatabase)
    {
        var mongoDB = new MongoClient(mongoDbDatabase.ConnectionString);
        var database = mongoDB.GetDatabase(mongoDbDatabase.DatabaseName);
        var userCollection = database.GetCollection<User>("User");
        var classCollection = database.GetCollection<Class>("Class");

        if (userCollection.FindSync(_ => true).Any())
        {
            return;
        }
        
        var options = new CreateIndexOptions { Unique = true };
        var userModel = new CreateIndexModel<User>("{Email: 1}", options);
        var classModel = new CreateIndexModel<Class>("{Name: 1}", options);
        var subjectModel = new CreateIndexModel<Class>("{\"Subjects.Name\": 1}", options);
        userCollection.Indexes.CreateOne(userModel);
        classCollection.Indexes.CreateOne(classModel);
        classCollection.Indexes.CreateOne(subjectModel);
        
        var admin = new User()
        {
            Name = "admin",
            Lastname = "admin",
            Email = "admin@example.com",
            Role = UserRole.Admin,
            PasswordHash = PasswordHash.MakePasswordHash("AdminPassword1"),
        };
        
        userCollection.InsertOne(admin);

    }
}