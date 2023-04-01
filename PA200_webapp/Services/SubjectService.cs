using AutoMapper;
using PA200_webapp.Infrastructure;
using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

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
        var userClass = _unitOfWork.SubjectRepository.AddStudentToSubject(subjectId, _mapper.Map<UserSubject>(dto));
        
        _unitOfWork.Save();
        return _mapper.Map<AddStudentToClassSubjectDTO>(userClass);
    }

    public WallDTO GetSubjectWall(string userEmail, int id)
    {
        return _mapper.Map<WallDTO>(_unitOfWork.WallRepository.GetWallForSubject(userEmail, id));
    }

    public CreatePostDTO CreatePost(string userEmail, int subjectId, CreatePostDTO dto)
    {
        var post = _unitOfWork.SubjectRepository.CreatePost(userEmail, subjectId, _mapper.Map<Post>(dto));
        
        _unitOfWork.Save();
        return _mapper.Map<CreatePostDTO>(post);
    }
    

    public void DeletePost(string userEmail, int subjectId, int postId)
    {
        var user = _unitOfWork.UserRepository.GetUserWithUserSubject(userEmail);
        var userSubject = user.UserSubjects.FirstOrDefault(u => u.SubjectId == subjectId);
        if (userSubject == null)
        {
            throw new Exception("User is not in the subject");
        }

        var post = _unitOfWork.PostRepository.GetPostWithUser(postId);

        if (post.Wall.Subject?.SubjectId != subjectId)
        {
            throw new Exception("what the fuck");
        }
        
        post.IsDeleted = true;
        if (user.Role == UserRole.Teacher || user.Role == UserRole.Admin)
        {
            _unitOfWork.PostRepository.Update(post);
            _unitOfWork.Save();
            return;
        }

        if (user.UserId != post.UserId)
        {
            throw new Exception("You are not authorized to remove others posts.");
        }
        
        _unitOfWork.PostRepository.Update(post); 
        _unitOfWork.Save();
    }

    public UpdatePostResponseModel UpdatePost(string userEmail, int postId, UpdatePostDTO dto)
    {
        var user = _unitOfWork.UserRepository.GetUserWithUserSubject(userEmail);
        
        var post = _unitOfWork.PostRepository.GetPostWithCommentsLikesWall(postId);

        if (post.UserId != user.UserId)
        {
            throw new Exception("You can't change other people's posts!");
        }

        if (post.IsDeleted)
        {
            throw new Exception("There is no post with that id");
        }

        post.Text = dto.Text;
        
        _unitOfWork.PostRepository.Update(post);
        _unitOfWork.Save();
        return _mapper.Map<UpdatePostResponseModel>(post);
    }
    
    
    
}