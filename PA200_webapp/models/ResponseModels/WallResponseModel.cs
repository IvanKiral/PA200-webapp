namespace PA200_webapp.models.ResponseModels;

public class WallPost
{
    public string AuthorName { get; set; }
    public string Text { get; set; }

    public int LikeCount { get; set; }
}

public class WallResponseModel
{
    public IEnumerable<WallPost> Posts { get; set; }
}