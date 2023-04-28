using AutoMapper;
using MongoDB.Bson;
using PA200_webapp.models.DTO;
using PA200_webapp.models.MongoDB;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Repository.MongoDB.Interfaces;

namespace PA200_webapp.Services.MongoDB;

public class SubjectService: ISubjectService
{
    
    private IMapper _mapper;

    private IUserRepository _userRepository;

    private ISubjectRepository _subjectRepository;

    private IPostRepository _postRepository;

    public SubjectService(IMapper mapper, IUserRepository userRepository, ISubjectRepository classRepository, IPostRepository postRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _subjectRepository = classRepository;
        _postRepository = postRepository;
    }

    public AddTeacherToClassSubjectDTO AddTeacherToSubject(string email, string subjectId, AddTeacherToClassSubjectDTO dto)
    {
        var newAttendance = _mapper.Map<Attends>(dto);
        newAttendance.AttendId = ObjectId.Parse(subjectId);
        var attends = _userRepository.AddUserAttends(email, newAttendance);
        return _mapper.Map<AddTeacherToClassSubjectDTO>(attends);
    }

    public AddStudentToClassSubjectDTO AddStudentToSubject(string subjectId, AddStudentToClassSubjectDTO dto)
    {
        var newAttendance = _mapper.Map<Attends>(dto);
        newAttendance.AttendId = ObjectId.Parse(subjectId);
        var attends = _userRepository.AddUserAttends(dto.UserEmail, newAttendance);
        
        return _mapper.Map<AddStudentToClassSubjectDTO>(attends);
    }

    public WallResponseModel GetSubjectWall(string userEmail, string subjectId)
    {
        var user = _userRepository.GetUserByEmail(userEmail);
        var classAttendance = user.Attends.FirstOrDefault(a => a.AttendId == ObjectId.Parse(subjectId));
        
        if (classAttendance == null)
        {
            throw new Exception("The user is not attendant of the subject class");
        }
        
        var time = DateTime.Now;

        if (time < classAttendance.From || time > classAttendance.To) 
        {
            throw new Exception("The user is not attendant of the given subject anymore");
        }
        
        var subjectWall =  _subjectRepository.GetWallWithPosts(subjectId);

        subjectWall.Posts =
            subjectWall.Posts.Where(p => p.Created >= classAttendance.From && p.Created <= classAttendance.To && !p.IsDeleted);

        return _mapper.Map<WallResponseModel>(subjectWall);
    }

    public CreatePostResponseModel CreatePost(string userEmail, string subjectId, CreatePostDTO dto)
    {
        var user = _userRepository.GetUserByEmail(userEmail);
        var classAttendance = user.Attends.FirstOrDefault(a => a.AttendId == ObjectId.Parse(subjectId));
        
        if (classAttendance == null)
        {
            throw new Exception("The user is not attendant of the subject class");
        }
        
        var time = DateTime.Now;

        if (time < classAttendance.From || time > classAttendance.To) 
        {
            throw new Exception("The user is not attendant of the given subject anymore");
        }
        
        var classWall = _subjectRepository.GetWall(subjectId);
        
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