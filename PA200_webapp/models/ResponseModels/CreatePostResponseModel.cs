namespace PA200_webapp.models.ResponseModels;

public class CreatePostResponseModel
{
    public int PostId { get; set; }
    public string Text { get; set; }
    public PostType Type { get; set; }
}