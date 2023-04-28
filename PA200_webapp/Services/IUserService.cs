using PA200_webapp.models.MongoDB;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services;

public interface IUserService
{
    public User? authenticateUser(LoginUserDTO user);

    public WallResponseModel GetUserWall(string email);

    public UserProfileResponseModel GetUserProfile(string email);
}