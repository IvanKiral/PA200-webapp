using AutoMapper;
using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Infrastructure.Profiles;

public class SchoolProfile: Profile
{
    public SchoolProfile()
    {
        CreateMap<Wall, SchoolWallDTO>();
        CreateMap<SchoolWallDTO, SchoolWallResponseModel>();
        CreateMap<Post, WallPost>()
            .BeforeMap((source, destination) =>
            {
                destination.AuthorName = source.User.Name;
            });;
    }
}