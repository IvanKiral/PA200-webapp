using AutoMapper;
using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Infrastructure.Profiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<RegisterRequestModel, RegisterUserDTO>();
        CreateMap<RegisterUserDTO, User>()
            .BeforeMap((source, destination) => destination.PasswordHash = source.Password);
        CreateMap<LoginUserRequest, LoginUserDTO>();
        CreateMap<User, UserProfileResponseModel>();
        CreateMap<UserClass, UserClassResponse>();
        CreateMap<UserSubject, UserSubjectResponse>();
        CreateMap<Class, UserProfileClassResponse>();
        CreateMap<Subject, UserProfileSubjectResponse>();
    }
}