using AutoMapper;
using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;

namespace PA200_webapp.Infrastructure.Profiles;

public class PostProfile: Profile
{
    public PostProfile()
    {
        CreateMap<CreatePostRequestModel, CreatePostDTO>();
        CreateMap<CreatePostDTO, Post>();
        CreateMap<Post, CreatePostDTO>();
    }
}