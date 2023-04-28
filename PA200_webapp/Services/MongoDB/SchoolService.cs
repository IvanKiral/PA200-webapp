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
    private IPostRepository _postRepository;
    private IMapper _mapper;

    public SchoolService(IMapper mapper, ISchoolRepository schoolRepository, IUserRepository userRepository, IPostRepository postRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _schoolRepository = schoolRepository;
        _postRepository = postRepository;
    }

    public WallResponseModel GetSchoolWall(string userEmail)
    {
        var schoolWall = _schoolRepository.GetWallWithPosts();
        schoolWall.Posts = schoolWall.Posts.Where(p => !p.IsDeleted);
        
        return _mapper.Map<WallResponseModel>(schoolWall);
    }

    public CreatePostResponseModel CreatePost(string userEmail, CreatePostDTO dto)
    {
        var user = _userRepository.GetUserByEmail(userEmail);
        var wall = _schoolRepository.GetWall();
        
        var newPost = _postRepository.Create(new Post()
        {
            Author = new PostAuthor()
            {
                AuthorId = user.Id,
                Name = user.Name + " " + user.Lastname
            },
            Text = dto.Text,
            WallId = wall.Id
        });

        return _mapper.Map<CreatePostResponseModel>(newPost);
    }
}