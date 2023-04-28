namespace PA200_webapp.models.ResponseModels;

public class GetSubjectsResponseModel
{
    public IEnumerable<MongoDB.Subject> Subjects { get; set; }
}