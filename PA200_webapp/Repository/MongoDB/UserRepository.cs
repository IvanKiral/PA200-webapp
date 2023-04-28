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
}