using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;

namespace PA200_webapp.Services;

public interface IUserService
{
    public void createUser(RegisterUserDTO model);
    public User? authenticateUser(LoginUserDTO user);
}