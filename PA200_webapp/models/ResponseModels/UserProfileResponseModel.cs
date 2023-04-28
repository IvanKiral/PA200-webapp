using PA200_webapp.models.MongoDB;

namespace PA200_webapp.models.ResponseModels;



public class UserProfileClassResponse
{
    public int ClassId { get; set; }
    public string Name { get; set; }
}

public class UserProfileSubjectResponse
{
    public int SubjectId { get; set; }
    public string Name { get; set; }
}

public class UserClassResponse
{
    public UserProfileClassResponse Class { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}
public class UserSubjectResponse
{
    public UserProfileSubjectResponse Subject { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}


public class UserProfileResponseModel
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public IEnumerable<Attends> Attends { get; set; }
}