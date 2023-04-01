using AutoMapper;
using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;

namespace PA200_webapp.Infrastructure.Profiles;

public class PostProfile: Profile
{
    public PostProfile()
    {
        CreateMap<CreatePostOnSchoolWallRequestModel, CreatePostOnSchoolWallDTO>();
        CreateMap<CreatePostOnSchoolWallDTO, Post>();
        CreateMap<Post, CreatePostOnSchoolWallDTO>();
    }
}