// using AutoMapper;
// using PA200_webapp.Infrastructure;
// using PA200_webapp.models;
// using PA200_webapp.models.DTO;
// using PA200_webapp.models.RequestModels;
// using PA200_webapp.models.ResponseModels;
// using PA200_webapp.Repository;
//
// namespace PA200_webapp.Services;
//
// public class ClassService: IClassService
// {
//     private IMapper _mapper;
//     private IUnitOfWork _unitOfWork;
//
//     public ClassService(IMapper mapper, IUnitOfWork unitOfWork)
//     {
//         _mapper = mapper;
//         _unitOfWork = unitOfWork;
//     }
//
//     public AddTeacherToClassSubjectDTO AddTeacherToClass(string email, int classID, AddTeacherToClassSubjectDTO dto)
//     {
//         dto.From = dto.From.ToUniversalTime();
//         dto.To = dto.To.ToUniversalTime();
//         var userClass = _unitOfWork.ClassRepository.AddUserToClass(email, classID, _mapper.Map<UserClass>(dto));
//         
//         
//         _unitOfWork.Save();
//         return _mapper.Map<AddTeacherToClassSubjectDTO>(userClass);
//     }
//
//     public AddStudentToClassSubjectDTO AddStudentToClass(int classID, AddStudentToClassSubjectDTO classDto)
//     {
//         classDto.From = classDto.From.ToUniversalTime();
//         classDto.To = classDto.To.ToUniversalTime();
//         var userClass = _unitOfWork.ClassRepository.AddStudentToClass(classID, _mapper.Map<UserClass>(classDto));
//         
//         _unitOfWork.Save();
//         return _mapper.Map<AddStudentToClassSubjectDTO>(userClass);
//     }
//
//     public WallDTO GetClassWall(string userEmail, int id)
//     {
//         return _mapper.Map<WallDTO>(_unitOfWork.WallRepository.GetWallForClass(userEmail, id));
//     }
//
//     public CreatePostResponseModel CreatePost(string userEmail, int classId, CreatePostDTO dto)
//     {
//         var post = _unitOfWork.ClassRepository.CreatePost(userEmail, classId, _mapper.Map<Post>(dto));
//                 
//         _unitOfWork.Save();
//         return _mapper.Map<CreatePostResponseModel>(post);
//     }
//
//     public void DeletePost(string userEmail, int classId, int postId)
//     {
//         var user = _unitOfWork.UserRepository.GetUserWithUserClass(userEmail);
//         var userSubject = user.UserClasses.FirstOrDefault(u => u.ClassId == classId);
//         if (userSubject == null)
//         {
//             throw new Exception("User is not in the subject");
//         }
//
//         var post = _unitOfWork.PostRepository.GetPostWithUser(postId);
//
//         if (post.Wall.Class?.ClassId != classId)
//         {
//             throw new Exception("what the fuck");
//         }
//         
//         post.IsDeleted = true;
//         if (user.Role == UserRole.Teacher || user.Role == UserRole.Admin)
//         {
//             _unitOfWork.PostRepository.Update(post);
//             _unitOfWork.Save();
//             return;
//         }
//
//         if (user.UserId != post.UserId)
//         {
//             throw new Exception("You are not authorized to remove others posts.");
//         }
//         
//         _unitOfWork.PostRepository.Update(post); 
//         _unitOfWork.Save();
//     }
//
//     public UpdatePostResponseModel UpdatePost(string userEmail, int postId, UpdatePostDTO dto)
//     {
//         var user = _unitOfWork.UserRepository.GetUserWithUserClass(userEmail);
//         
//         var post = _unitOfWork.PostRepository.GetPostWithCommentsLikesWall(postId);
//
//         if (post.UserId != user.UserId)
//         {
//             throw new Exception("You can't change other people's posts!");
//         }
//
//         if (post.IsDeleted)
//         {
//             throw new Exception("There is no post with that id");
//         }
//
//         post.Text = dto.Text;
//         
//         _unitOfWork.PostRepository.Update(post);
//         _unitOfWork.Save();
//         return _mapper.Map<UpdatePostResponseModel>(post);
//     }
// }