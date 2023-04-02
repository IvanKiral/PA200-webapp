using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services;

public interface IUserService
{
    public CreateUserResponseModel createUser(CreateUserDTO model);
    public User? authenticateUser(LoginUserDTO user);

    public WallResponseModel GetUserWall(string email);
}