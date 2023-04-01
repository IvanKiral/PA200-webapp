using Microsoft.EntityFrameworkCore;
using PA200_webapp.DB;
using PA200_webapp.models;

namespace PA200_webapp.Repository;

public class UserRepository: RepositoryBase<User>, IUserRepository
{
    public UserRepository(SocialNetworkContext socialNetworkContext) : base(socialNetworkContext)
    {
    }

    public User? GetUserWithSchool(string email)
    {
        return SocialNetworkContext.Users
            .Include("School")
            .Include("School.Wall")
            .Include("School.Wall.Posts")
            .Include("School.Wall.Posts.User")
            .FirstOrDefault(u => u.Email == email);
    }
    
}