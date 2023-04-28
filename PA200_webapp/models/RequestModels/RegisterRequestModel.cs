using PA200_webapp.models.MongoDB;

namespace PA200_webapp.models.RequestModels;

public class RegisterRequestModel
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}