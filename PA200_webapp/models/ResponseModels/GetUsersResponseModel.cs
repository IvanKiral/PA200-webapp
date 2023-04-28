namespace PA200_webapp.models.ResponseModels;

public class GetUsersResponseModel
{
    public IEnumerable<MongoDB.User> Users { get; set; }
}