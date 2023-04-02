namespace PA200_webapp.models.ResponseModels;

public class CreateUserResponseModel
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; }
    public int SchoolId { get; set; }
}