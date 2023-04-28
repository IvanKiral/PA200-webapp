//
// using AutoMapper;
// using PA200_webapp.Infrastructure;
// using PA200_webapp.models;
// using PA200_webapp.models.DTO;
// using PA200_webapp.models.ResponseModels;
//
// namespace PA200_webapp.Services;
//
// public class SchoolService: ISchoolService
// {
//     private IUnitOfWork _unitOfWork;
//     private IMapper _mapper;
//
//     public SchoolService(IUnitOfWork unitOfWork, IMapper mapper)
//     {
//         _unitOfWork = unitOfWork;
//         _mapper = mapper;
//     }
//
//     public WallDTO GetSchoolWall(string userEmail)
//     {
//         var user = _unitOfWork.UserRepository.GetUserWithSchool(userEmail);
//
//         if (user == null)
//         {
//             throw new ArgumentException("UserEmail was not found");
//         }
//         
//         var wall = user.School.Wall;
//         user.School.Wall.Posts = wall.Posts.Where(p => p.Type == PostType.Post);
//
//         return _mapper.Map<WallDTO>(user.School.Wall);
//     }
//
//     public CreatePostResponseModel CreatePost(string userEmail, CreatePostDTO dto)
//     {
//
//         var post = _unitOfWork.PostRepository.CreatePostOnSchoolWall(userEmail,_mapper.Map<Post>(dto));
//         _unitOfWork.Save();
//
//         return _mapper.Map<CreatePostResponseModel>(post);
//     }
// }