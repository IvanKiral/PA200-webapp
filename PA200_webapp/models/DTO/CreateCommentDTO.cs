using PA200_webapp.models.MongoDB;

namespace PA200_webapp.models.DTO;

public class CreateCommentDTO
{
    public string Text { get; set; }
    public PostAuthor Author { get; set; }
}