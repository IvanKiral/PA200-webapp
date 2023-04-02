using PA200_webapp.models;

namespace PA200_webapp.Repository;

public interface IUserRepository: IRepositoryBase<User>
{
    public User? GetUserWithSchool(string email);
    public User GetUserWithUserSubject(string email);
    
    public User GetUserWithUserClass(string email);

    public Wall GetUserWall(string email);

    public User GetUserWithSubjectsAndClasses(string userEmail);

}