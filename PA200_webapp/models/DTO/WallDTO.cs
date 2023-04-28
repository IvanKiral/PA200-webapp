using PA200_webapp.models.MongoDB;

namespace PA200_webapp.models.DTO;


public class WallDTO
{
    public IEnumerable<Post> posts { get; set; }
}