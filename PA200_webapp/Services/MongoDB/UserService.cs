using PA200_webapp.models.MongoDB;
using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Repository.MongoDB.Interfaces;
using PA200_webapp.Utils;

namespace PA200_webapp.Services.MongoDB;

public class UserService: IUserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public CreateUserResponseModel createUser(CreateUserDTO model)
    {
        throw new NotImplementedException();
    }

    public User? authenticateUser(LoginUserDTO user)
    {
        var u = _userRepository.FilterBy(u => u.Email == user.Email).FirstOrDefault();
        if (u == null)
        {
            return null;
        }

        if (PasswordHash.ComparePasswords(user.Password, u.PasswordHash))
        {
            return u;
        }

        return null;
    }

    public WallResponseModel GetUserWall(string email)
    {
        throw new NotImplementedException();
    }

    public UserProfileResponseModel GetUserProfile(string emial)
    {
        throw new NotImplementedException();
    }
}