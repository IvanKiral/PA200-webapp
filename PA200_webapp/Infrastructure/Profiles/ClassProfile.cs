using AutoMapper;
using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;

namespace PA200_webapp.Infrastructure.Profiles;

public class ClassProfile: Profile
{
    public ClassProfile()
    {
        CreateMap<AddStudentToClassRequestModel, AddStudentToClassSubjectDTO>();
        CreateMap<AddTeacherToClassRequestModel, AddTeacherToClassSubjectDTO>();
        
        CreateMap<AddTeacherToClassSubjectDTO, UserClass>();
        CreateMap<UserClass, AddTeacherToClassSubjectDTO>();

        CreateMap<AddStudentToClassSubjectDTO, UserClass>();
        CreateMap<UserClass, AddStudentToClassSubjectDTO>();
        
        CreateMap<AddTeacherToClassSubjectDTO, UserSubject>();
        CreateMap<UserSubject, AddTeacherToClassSubjectDTO>();
        
        CreateMap<AddStudentToClassSubjectDTO, UserSubject>();
        CreateMap<UserSubject, AddStudentToClassSubjectDTO>();
    }
}