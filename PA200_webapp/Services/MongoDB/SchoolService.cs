using AutoMapper;
using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.MongoDB;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Repository.MongoDB.Interfaces;
using Post = PA200_webapp.models.MongoDB.Post;

namespace PA200_webapp.Services.MongoDB;

public class SchoolService: ISchoolService
{
    private ISchoolRepository _schoolRepository;
    private IUserRepository _userRepository;
    private IMapper _mapper;

    public SchoolService(IMapper mapper, ISchoolRepository schoolRepository, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _schoolRepository = schoolRepository;
    }

    public WallResponseModel GetSchoolWall(string userEmail)
    {
        return _mapper.Map<WallResponseModel>(_schoolRepository.GetWall());
        
    }

    public CreatePostResponseModel CreatePost(string userEmail, CreatePostDTO dto)
    {
        var user = _userRepository.GetUserByEmail(userEmail);
        
        var newPost = _schoolRepository.CreatePostOnWall(new Post()
        {
            Author = new PostAuthor()
            {
                AuthorId = user.Id,
                Name = user.Name + " " + user.Lastname
            },
            Text = dto.Text,
            Type = PostType.Post
        });

        return _mapper.Map<CreatePostResponseModel>(newPost);
    }
}