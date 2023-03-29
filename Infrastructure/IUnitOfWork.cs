using PA200_webapp.Repository;

namespace PA200_webapp.Infrastructure;

public interface IUnitOfWork
{
    IClassRepository ClassRepository { get; }
    ICommentRepository CommentRepository { get; }
    ILikeRepository LikeRepository { get; }
    IPostRepository PostRepository { get; }
    ISubjectRepository SubjectRepository { get; }
    IUserRepository UserRepository { get; }
    IWallRepository WallRepository { get; }
    void Save();
}