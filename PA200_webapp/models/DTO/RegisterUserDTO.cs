namespace PA200_webapp.models.DTO;

public class RegisterUserDTO
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}