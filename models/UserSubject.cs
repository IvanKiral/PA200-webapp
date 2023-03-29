namespace PA200_webapp.models;

public class UserSubject
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int SubjectId { get; set; }
    public Class Subject { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}