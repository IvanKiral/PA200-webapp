namespace PA200_webapp.DB;

public class MongoDBDatabase: IMongoDatabase
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;
}