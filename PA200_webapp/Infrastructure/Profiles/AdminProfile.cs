using AutoMapper;
using PA200_webapp.models.MongoDB;
using PA200_webapp.models.DTO;
using PA200_webapp.models.DTO.Create;
using PA200_webapp.models.RequestModels;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Infrastructure.Profiles;

public class AdminProfile: Profile
{
    public AdminProfile()
    {
        CreateMap<CreateUserRequestModel, CreateUserDTO>();
        CreateMap<CreateUserDTO, User>();
        
        CreateMap<CreateClassRequestModel, CreateClassDTO>();
        CreateMap<CreateClassDTO, Class>();
        CreateMap<Class, ClassCreatedDto>();
        
        
        CreateMap<CreateSchoolRequestModel, CreateSchoolDTO>();
        CreateMap<CreateSubjectRequestModel, CreateSubjectDTO>();
        
        
        CreateMap<CreateSchoolDTO, School>();
        CreateMap<CreateSubjectDTO, Subject>();
        CreateMap<ClassCreatedDto, CreateClassResponseModel>();
        CreateMap<SchoolCreatedDTO, CreateSchoolResponseModel>();
        CreateMap<SubjectCreatedDTO, CreateSubjectResponseModel>();
        
        CreateMap<School, SchoolCreatedDTO>();
        CreateMap<Subject, SubjectCreatedDTO>();
        CreateMap<User, CreateUserResponseModel>();
    }
}