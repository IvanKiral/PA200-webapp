using AutoMapper;
using PA200_webapp.Infrastructure;
using PA200_webapp.models;
using PA200_webapp.models.DTO;

namespace PA200_webapp.Services;

public class SubjectService: ISubjectService
{
    
    private IMapper _mapper;
    private IUnitOfWork _unitOfWork;

    public SubjectService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public AddTeacherToClassSubjectDTO AddTeacherToSubject(string email, int subjectId, AddTeacherToClassSubjectDTO dto)
    {
        dto.From = dto.From.ToUniversalTime();
        dto.To = dto.To.ToUniversalTime();
        var userClass = _unitOfWork.SubjectRepository.AddUserToSubject(email, subjectId, _mapper.Map<UserSubject>(dto));
        
        
        _unitOfWork.Save();
        return _mapper.Map<AddTeacherToClassSubjectDTO>(userClass);
    }

    public AddStudentToClassSubjectDTO AddStudentToSubject(int subjectId, AddStudentToClassSubjectDTO dto)
    {
        dto.From = dto.From.ToUniversalTime();
        dto.To = dto.To.ToUniversalTime();
        var userClass = _unitOfWork.ClassRepository.AddStudentToClass(subjectId, _mapper.Map<UserClass>(dto));
        
        _unitOfWork.Save();
        return _mapper.Map<AddStudentToClassSubjectDTO>(userClass);
    }
}