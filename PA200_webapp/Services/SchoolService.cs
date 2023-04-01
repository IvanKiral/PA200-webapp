
using AutoMapper;
using PA200_webapp.Infrastructure;
using PA200_webapp.models;
using PA200_webapp.models.DTO;

namespace PA200_webapp.Services;

public class SchoolService: ISchoolService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public SchoolService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public SchoolWallDTO GetSchoolWall(string userEmail)
    {
        var user = _unitOfWork.UserRepository.GetUserWithSchool(userEmail);

        if (user == null)
        {
            throw new ArgumentException("UserEmail was not found");
        }

        return _mapper.Map<SchoolWallDTO>(user.School.Wall);
    }

    public CreatePostOnSchoolWallDTO CreatePost(string userEmail, CreatePostOnSchoolWallDTO dto)
    {

        var post = _unitOfWork.PostRepository.CreatePostOnSchoolWall(userEmail,_mapper.Map<Post>(dto));
        _unitOfWork.Save();

        return _mapper.Map<CreatePostOnSchoolWallDTO>(post);
    }
}