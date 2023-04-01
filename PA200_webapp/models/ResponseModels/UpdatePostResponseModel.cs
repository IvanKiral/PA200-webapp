namespace PA200_webapp.models.ResponseModels;

public class UpdatePostResponseModel
{
    public string Text { get; set; }
    public int PostId { get; set; }
    public IEnumerable<Post> Comments { get; set; }
    public IEnumerable<Like> Likes { get; set; }
}