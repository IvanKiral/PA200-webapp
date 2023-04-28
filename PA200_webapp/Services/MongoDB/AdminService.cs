using AutoMapper;
using PA200_webapp.models.DTO;
using PA200_webapp.models.DTO.Create;
using PA200_webapp.models.MongoDB;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Repository.MongoDB.Interfaces;
using PA200_webapp.Utils;
using IUserRepository = PA200_webapp.Repository.MongoDB.Interfaces.IUserRepository;

namespace PA200_webapp.Services.MongoDB;

public class AdminService: IAdminService
{
    private IUserRepository _userRepository;
    private IClassRepository _classRepository;
    private IMapper _mapper;

    public AdminService(IMapper mapper, IUserRepository userRepository, IClassRepository classRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _classRepository = classRepository;
    }

    public SchoolCreatedDTO CreateSchool(CreateSchoolDTO schoolDto)
    {
        throw new NotImplementedException();
    }

    public ClassCreatedDto CreateClass(CreateClassDTO classDto)
    {
        var classEntity = _classRepository.Create(_mapper.Map<Class>(classDto));
        return _mapper.Map<ClassCreatedDto>(classEntity);
    }

    public SubjectCreatedDTO CreateSubject(CreateSubjectDTO subjectDto)
    {
        var subjectEntity = _classRepository.CreateSubject(subjectDto.ClassId, _mapper.Map<Subject>(subjectDto));
        return _mapper.Map<SubjectCreatedDTO>(subjectEntity);
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
        var classes = _classRepository.GetAll();
        return new GetClassesResponseModel()
        {
            Classes = classes
        };
    }

    public GetSubjectsResponseModel GetSubjects()
    {
        return new GetSubjectsResponseModel()
        {
            Subjects = _classRepository.GetAllSubjects()
        };
    }

    public CreateUserResponseModel createUser(CreateUserDTO model)
    { 
        var hashedPassword = PasswordHash.MakePasswordHash(model.Password); 
        var user = _mapper.Map<User>(model);
        user.PasswordHash = hashedPassword;
        var entity = _userRepository.Create(user);
        return _mapper.Map<CreateUserResponseModel>(entity);
    }
}