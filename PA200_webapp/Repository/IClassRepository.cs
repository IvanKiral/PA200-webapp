using PA200_webapp.models;
using PA200_webapp.models.RequestModels;

namespace PA200_webapp.Repository;

public interface IClassRepository: IRepositoryBase<Class>
{
    public Class createClass(Class newClass);

    public UserClass AddUserToClass(string userEmail, int classId, UserClass userClass);

    public UserClass AddStudentToClass(int classId, UserClass userClass);
    
    public Post CreatePost(string userEmail, int classId, Post post);
}