using AutoMapper;
using MongoDB.Driver.Linq;
using PA200_webapp.models.MongoDB;
using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Repository.MongoDB.Interfaces;
using PA200_webapp.Utils;

namespace PA200_webapp.Services.MongoDB;

public class UserService: IUserService
{
    private IMapper _mapper;
    private IUserRepository _userRepository;
    private ISchoolRepository _schoolRepository;
    private IClassRepository _classRepository;
    private ISubjectRepository _subjectRepository;

    public UserService(IMapper mapper, IUserRepository userRepository, ISchoolRepository schoolRepository, IClassRepository classRepository, ISubjectRepository subjectRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _schoolRepository = schoolRepository;
        _classRepository = classRepository;
        _subjectRepository = subjectRepository;
    }

    public User? authenticateUser(LoginUserDTO user)
    {
        var u = _userRepository.FilterBy(u => u.Email == user.Email).FirstOrDefault();
        if (u == null)
        {
            return null;
        }

        if (PasswordHash.ComparePasswords(user.Password, u.PasswordHash))
        {
            return u;
        }

        return null;
    }

    public WallResponseModel GetUserWall(string email)
    {
        var user = _userRepository.GetUserByEmail(email);
        var resultWall = _schoolRepository.GetWallWithPosts();

        foreach (var attendance in user.Attends)
        {
            IEnumerable<Post> tmpWall;
            if (attendance.Type == AttendType.Class)
            {
                tmpWall = _classRepository.GetWallWithPosts(attendance.AttendId.ToString()).Posts;
            }
            else
            {
                tmpWall = _subjectRepository.GetWallWithPosts(attendance.AttendId.ToString()).Posts;
            }
            
            resultWall.Posts = resultWall.Posts.Concat(tmpWall.Where(p => p.Created >= attendance.From && p.Created <= attendance.To));
        }

        resultWall.Posts.Where(p => !p.IsDeleted);

        return _mapper.Map <WallResponseModel>(resultWall);
    }

    public UserProfileResponseModel GetUserProfile(string email)
    {
        var user = _userRepository.GetUserByEmail(email);

        return _mapper.Map<UserProfileResponseModel>(user);
    }
}