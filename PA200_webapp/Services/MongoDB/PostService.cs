using AutoMapper;
using MongoDB.Bson;
using PA200_webapp.models.DTO;
using PA200_webapp.models.MongoDB;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Repository.MongoDB.Interfaces;

namespace PA200_webapp.Services.MongoDB;

public class PostService: IPostService
{
    private IMapper _mapper;
    private IPostRepository _postRepository;
    private IUserRepository _userRepository;

    public PostService(IMapper mapper, IPostRepository postRepository, IUserRepository userRepository)
    {
        _mapper = mapper;
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public void LikePost(string userEmail, string postId)
    {
        var user = _userRepository.GetUserByEmail(userEmail);
        var post = _postRepository.FilterBy(p => p.Id == ObjectId.Parse(postId)).First();

        if (post.Likes.Contains(user.Id))
        {
            throw new Exception("Given user already liked the post");
        }
        
        _postRepository.CreateLike(postId, user.Id);
    }

    public void DeleteLike(string userEmail, string postId)
    {
        var user = _userRepository.GetUserByEmail(userEmail);
        var post = _postRepository.FilterBy(p => p.Id == ObjectId.Parse(postId)).First();

        if (!post.Likes.Contains(user.Id))
        {
            throw new Exception("Given user did not have liked the post");
        }
        
        _postRepository.DeleteLike(postId, user.Id);
    }

    public CreatePostResponseModel CreateComment(string userEmail, string parentPostId, CreatePostDTO dto)
    {
        var user = _userRepository.GetUserByEmail(userEmail);

        return _mapper.Map<CreatePostResponseModel>(_postRepository.CreateComment(parentPostId, new CreateCommentDTO()
        {
            Text = dto.Text,
            Author = new PostAuthor()
            {
                AuthorId = user.Id,
                Name = $"{user.Name} {user.Lastname}"
            }
        }));
    }

    public WallPost GetPost(string postId)
    {
        var post = _postRepository.FilterBy(p => p.Id == ObjectId.Parse(postId)).First();

        if (post == null || post.IsDeleted)
        {
            throw new Exception("There is no such post");
        }
        
        return _mapper.Map<WallPost>(post);
    }

    public void DeletePost(string userEmail, string postId)
    {
        var user = _userRepository.GetUserByEmail(userEmail);
        var post = _postRepository.FilterBy(p => p.Id == ObjectId.Parse(postId)).First();

        if (post.Author.AuthorId != user.Id)
        {
            throw new Exception("You are not owner of this post");
        }
        
        _postRepository.DeletePost(postId);
    }

    public UpdatePostResponseModel UpdatePost(string userEmail, string postId, UpdatePostDTO dto)
    {
        var user = _userRepository.GetUserByEmail(userEmail);
        var post = _postRepository.FilterBy(p => p.Id == ObjectId.Parse(postId)).First();

        if (post.Author.AuthorId != user.Id)
        {
            throw new Exception("You are not owner of this post");
        }
        
        return _mapper.Map<UpdatePostResponseModel>(_postRepository.UpdatePostText(postId, dto.Text));
    }
}