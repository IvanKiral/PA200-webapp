using PA200_webapp.models.MongoDB;

namespace PA200_webapp.models.DTO;

public class CreateUserDTO
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
    public int SchoolId { get; set; } = 1;
}