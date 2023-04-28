// using AutoMapper;
// using PA200_webapp.Infrastructure;
// using PA200_webapp.models;
// using PA200_webapp.models.DTO;
// using PA200_webapp.models.RequestModels;
// using PA200_webapp.models.ResponseModels;
// using PA200_webapp.Utils;
//
// namespace PA200_webapp.Services;
//
// public class UserService: IUserService
// // {
//  z   private IUnitOfWork _unitOfWork;
//     private IMapper _mapper;
//     public UserService(IUnitOfWork unitOfWork, IMapper mapper)
//     {
//         _unitOfWork = unitOfWork;
//         _mapper = mapper;
//     }
//
//     public CreateUserResponseModel createUser(CreateUserDTO model)
//     {
//         var hashedPassword = PasswordHash.MakePasswordHash(model.Password);
//         var user = _mapper.Map<User>(model);
//         user.PasswordHash = hashedPassword;
//         var entity = _unitOfWork.UserRepository.Create(user);
//         _unitOfWork.Save();
//         return _mapper.Map<CreateUserResponseModel>(entity);
//     }
//
//     public User? authenticateUser(LoginUserDTO user)
//     {
//         var u = _unitOfWork.UserRepository.FindByCondition(u => u.Email == user.Email).FirstOrDefault();
//         if (u == null)
//         {
//             return null;
//         }
//
//         if (PasswordHash.ComparePasswords(user.Password, u.PasswordHash))
//         {
//             return u;
//         }
//
//         return null;
//     }
//
//     public WallResponseModel GetUserWall(string email)
//     {
//         return _mapper.Map<WallResponseModel>(_mapper.Map<WallDTO>(_unitOfWork.UserRepository.GetUserWall(email)));
//     }
//
//     public UserProfileResponseModel GetUserProfile(string email)
//     {
//         var user = _unitOfWork.UserRepository.GetUserWithSubjectsAndClasses(email);
//
//         return _mapper.Map<UserProfileResponseModel>(user);
//     }
// }