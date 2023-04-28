using PA200_webapp.models.DTO;
using PA200_webapp.models.DTO.Create;
using PA200_webapp.models.MongoDB;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Repository.MongoDB.Interfaces;

namespace PA200_webapp.Services.MongoDB;

public class AdminService: IAdminService
{
    private IUserRepository _userRepository;

    public AdminService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public SchoolCreatedDTO CreateSchool(CreateSchoolDTO schoolDto)
    {
        throw new NotImplementedException();
    }

    public ClassCreatedDto CreateClass(CreateClassDTO classDto)
    {
        throw new NotImplementedException();
    }

    public SubjectCreatedDTO CreateSubject(CreateSubjectDTO subjectDto)
    {
        throw new NotImplementedException();
    }

    public GetUsersResponseModel GetUsers()
    {
        var users = _userRepository.GetAll();
        return new GetUsersResponseModel
        {
            Users = users
        };
    }

    public GetClassesResponseModel GetClasses()
    {
        throw new NotImplementedException();
    }

    public GetSubjectsResponseModel GetSubjects()
    {
        throw new NotImplementedException();
    }
}