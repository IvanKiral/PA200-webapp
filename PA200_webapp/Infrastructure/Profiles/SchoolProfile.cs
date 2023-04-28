using AutoMapper;
using PA200_webapp.models.MongoDB;
using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Infrastructure.Profiles;

public class SchoolProfile: Profile
{
    public SchoolProfile()
    {
        CreateMap<WallWithPosts, WallDTO>();
        CreateMap<WallWithPosts, WallResponseModel>();
        CreateMap<WallDTO, WallResponseModel>();
        CreateMap<Post, WallPost>()
            .BeforeMap((source, destination) =>
            {
                destination.AuthorName = source.Author.Name;
                destination.LikeCount = source.Likes.Count();
            });;
        
        CreateMap<Comment, WallComment>()
            .BeforeMap((source, destination) =>
            {
                destination.AuthorName = source.Author.Name;
                destination.LikeCount = source.Likes.Count();
            });;
    }
}