using AutoMapper;
using PA200_webapp.Infrastructure;
using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;
using PA200_webapp.Repository;

namespace PA200_webapp.Services;

public class ClassService: IClassService
{
    private IMapper _mapper;
    private IUnitOfWork _unitOfWork;

    public ClassService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public AddTeacherToClassSubjectDTO AddTeacherToClass(string email, int classID, AddTeacherToClassSubjectDTO dto)
    {
        dto.From = dto.From.ToUniversalTime();
        dto.To = dto.To.ToUniversalTime();
        var userClass = _unitOfWork.ClassRepository.AddUserToClass(email, classID, _mapper.Map<UserClass>(dto));
        
        
        _unitOfWork.Save();
        return _mapper.Map<AddTeacherToClassSubjectDTO>(userClass);
    }

    public AddStudentToClassSubjectDTO AddStudentToClass(int classID, AddStudentToClassSubjectDTO classDto)
    {
        classDto.From = classDto.From.ToUniversalTime();
        classDto.To = classDto.To.ToUniversalTime();
        var userClass = _unitOfWork.ClassRepository.AddStudentToClass(classID, _mapper.Map<UserClass>(classDto));
        
        _unitOfWork.Save();
        return _mapper.Map<AddStudentToClassSubjectDTO>(userClass);
    }

    public WallDTO GetClassWall(string userEmail, int id)
    {
        return _mapper.Map<WallDTO>(_unitOfWork.WallRepository.GetWallForClass(userEmail, id));
    }

    public CreatePostDTO CreatePost(string userEmail, int classId, CreatePostDTO dto)
    {
        var post = _unitOfWork.ClassRepository.CreatePost(userEmail, classId, _mapper.Map<Post>(dto));
                
        _unitOfWork.Save();
        return _mapper.Map<CreatePostDTO>(post);
    }
}