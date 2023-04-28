using AutoMapper;
using MongoDB.Bson;
using PA200_webapp.models.DTO;
using PA200_webapp.models.MongoDB;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Repository.MongoDB.Interfaces;

namespace PA200_webapp.Services.MongoDB;

public class ClassService: IClassService
{
    private IMapper _mapper;
    private IUserRepository _userRepository;
    private IClassRepository _classRepository;
    private IPostRepository _postRepository;

    public ClassService(IMapper mapper, IUserRepository userRepository, IClassRepository classRepository, IPostRepository postRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _classRepository = classRepository;
        _postRepository = postRepository;
    }

    public AddTeacherToClassSubjectDTO AddTeacherToClass(string email, string classID, AddTeacherToClassSubjectDTO dto)
    {
        var newAttendance = _mapper.Map<Attends>(dto);
        newAttendance.AttendId = ObjectId.Parse(classID);
        var attends = _userRepository.AddUserAttends(email, newAttendance);
        
        return _mapper.Map<AddTeacherToClassSubjectDTO>(attends);
    }

    public AddStudentToClassSubjectDTO AddStudentToClass(string classID, AddStudentToClassSubjectDTO subjectDto)
    {
        var newAttendance = _mapper.Map<Attends>(subjectDto);
        newAttendance.AttendId = ObjectId.Parse(classID);
        var attends = _userRepository.AddUserAttends(subjectDto.UserEmail, newAttendance);
        
        return _mapper.Map<AddStudentToClassSubjectDTO>(attends);
    }

    public WallResponseModel GetClassWall(string userEmail, string classId)
    {
        var user = _userRepository.GetUserByEmail(userEmail);
        var classAttendance = user.Attends.FirstOrDefault(a => a.AttendId == ObjectId.Parse(classId));
        
        if (classAttendance == null)
        {
            throw new Exception("The user is not attendant of the given class");
        }
        
        var time = DateTime.Now;

        if (time < classAttendance.From || time > classAttendance.To) 
        {
            throw new Exception("The user is not attendant of the given class anymore");
        }
        
        var classWall =  _classRepository.GetWallWithPosts(classId);

        classWall.Posts =
            classWall.Posts.Where(p => p.Created >= classAttendance.From && p.Created <= classAttendance.To && !p.IsDeleted);

        return _mapper.Map<WallResponseModel>(classWall);
    }

    public CreatePostResponseModel CreatePost(string userEmail, string classId, CreatePostDTO dto)
    {
        var user = _userRepository.GetUserByEmail(userEmail);
        
        var classAttendance = user.Attends.FirstOrDefault(a => a.AttendId == ObjectId.Parse(classId));
        
        if (classAttendance == null)
        {
            throw new Exception("The user is not attendant of the given class");
        }
        
        var time = DateTime.Now;

        if (time < classAttendance.From || time > classAttendance.To) 
        {
            throw new Exception("The user is not attendant of the given class anymore");
        }
        
        var classWall = _classRepository.GetWall(classId);
        
        var newPost = _postRepository.Create(new Post()
        {
            Author = new PostAuthor()
            {
                AuthorId = user.Id,
                Name = user.Name + " " + user.Lastname
            },
            WallId = classWall.Id,
            Text = dto.Text
        });
        
        return _mapper.Map<CreatePostResponseModel>(newPost);
    }
}