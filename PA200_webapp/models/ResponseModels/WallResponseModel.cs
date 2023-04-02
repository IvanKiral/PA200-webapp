namespace PA200_webapp.models.ResponseModels;

public class WallPost
{
    public int PostId { get; set; }
    public string AuthorName { get; set; }
    public string Text { get; set; }
    public PostType Type { get; set; }

    public IEnumerable<WallPost> Comments { get; set; }

    public int LikeCount { get; set; }
}

public class WallResponseModel
{
    public IEnumerable<WallPost> Posts { get; set; }
}