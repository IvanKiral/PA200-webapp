using MongoDB.Bson;

namespace PA200_webapp.models.ResponseModels;


public class WallComment
{
    public ObjectId Id { get; set; }
    public string AuthorName { get; set; }
    public string Text { get; set; }
    public int LikeCount { get; set; }
}

public class WallPost
{
    public ObjectId Id { get; set; }
    public string AuthorName { get; set; }
    public string Text { get; set; }

    public IEnumerable<WallComment> Comments { get; set; }
    public int LikeCount { get; set; }
}

public class WallResponseModel
{
    public IEnumerable<WallPost> Posts { get; set; }
}