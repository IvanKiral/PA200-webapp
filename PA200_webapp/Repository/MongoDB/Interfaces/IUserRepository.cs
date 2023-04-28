using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB.Interfaces;

public interface IUserRepository: IBaseRepository<User>
{

    public User GetUserByEmail(string userEmail);
}