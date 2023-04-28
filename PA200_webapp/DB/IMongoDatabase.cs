namespace PA200_webapp.DB;

public interface IMongoDatabase
{
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }
    
}