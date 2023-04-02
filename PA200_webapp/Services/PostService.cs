using AutoMapper;
using PA200_webapp.Infrastructure;
using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Services;

public class PostService: IPostService
{
    private IMapper _mapper;
    private IUnitOfWork _unitOfWork;

    public PostService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public void LikePost(string userEmail, int postId)
    {
        var user = _unitOfWork.UserRepository.FindByCondition(u => u.Email == userEmail).FirstOrDefault();
        
        _unitOfWork.LikeRepository.Create(new Like()
        {
            PostId = postId,
            UserId = user.UserId
        });
        
        _unitOfWork.Save();
    }

    public void DeleteLike(string userEmail, int postId)
    {
        var post = _unitOfWork.PostRepository.GetPostWithUser(postId);
        var user = _unitOfWork.UserRepository.FindByCondition(u => u.Email == userEmail).FirstOrDefault();

        var like = _unitOfWork.LikeRepository.FindByCondition(l => l.UserId == user.UserId && l.PostId == postId).FirstOrDefault();

        if (like == null)
        {
            throw new Exception("that like does not exists");
        }

        _unitOfWork.LikeRepository.Delete(like);
        _unitOfWork.Save();
    }

    public CreatePostResponseModel CreateComment(string userEmail, int parentPostId, CreatePostDTO dto)
    {
        var user = _unitOfWork.UserRepository.FindByCondition(u => u.Email == userEmail).FirstOrDefault();

        var parentPost = _unitOfWork.PostRepository.FindByCondition(p => p.PostId == parentPostId).FirstOrDefault();

        var newPost = _unitOfWork.PostRepository.CreateComment(new Post()
        {
            UserId = user.UserId,
            Text = dto.Text,
            Type = PostType.Comment,
            WallId = parentPost.WallId,
            ParentPostId = parentPostId,
            Created = DateTime.Now.ToUniversalTime()
        });
        
        _unitOfWork.Save();

        return _mapper.Map<CreatePostResponseModel>(newPost);

    }

    public WallPost GetPost(int postId)
    {
        var post = _unitOfWork.PostRepository.GetPostWithCommentsLikesWall(postId);
        return _mapper.Map<WallPost>(post);
    }
}