using System.Security.Claims;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Infrastructure;

public interface IAuthService
{
    string generateToken(User user);
}