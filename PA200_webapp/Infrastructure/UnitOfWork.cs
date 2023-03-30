using PA200_webapp.DB;
using PA200_webapp.models;
using PA200_webapp.Repository;

namespace PA200_webapp.Infrastructure;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private SocialNetworkContext context;

    private IClassRepository _classRepository;
    private ICommentRepository _commentRepository;
    private ILikeRepository _likeRepository;
    private IPostRepository _postRepository;
    private ISubjectRepository _subjectRepository;
    private IUserRepository _userRepository;
    private IWallRepository _wallRepository;

    public IClassRepository ClassRepository
    {
        get
        {
            if (_classRepository == null)
            {
                _classRepository = new ClassRepository(context);
            }

            return _classRepository;
        }
    }

    public ICommentRepository CommentRepository
    {
        get
        {
            if (_commentRepository == null)
            {
                _commentRepository = new CommentRepository(context);
            }

            return _commentRepository;
        }
    }

    public ILikeRepository LikeRepository
    {
        get
        {
            if (_likeRepository == null)
            {
                _likeRepository = new LikeRepository(context);
            }

            return _likeRepository;
        }
    }

    public IPostRepository PostRepository
    {
        get
        {
            if (_postRepository == null)
            {
                _postRepository = new PostRepository(context);
            }

            return _postRepository;
        }
    }

    public ISubjectRepository SubjectRepository
    {
        get
        {
            if (_subjectRepository == null)
            {
                _subjectRepository = new SubjectRepository(context);
            }

            return _subjectRepository;
        }
    }

    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(context);
            }

            return _userRepository;
        }
    }

    public IWallRepository WallRepository
    {
        get
        {
            if (_wallRepository == null)
            {
                _wallRepository = new WallRepository(context);
            }

            return _wallRepository;
        }
    }

    public UnitOfWork(SocialNetworkContext socialNetworkContext)
    {
        context = socialNetworkContext;
    }

    public void Save()
    {
        context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }

        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}