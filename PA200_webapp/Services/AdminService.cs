// using AutoMapper;
// using PA200_webapp.Infrastructure;
// using PA200_webapp.models;
// using PA200_webapp.models.DTO;
// using PA200_webapp.models.DTO.Create;
// using PA200_webapp.models.ResponseModels;
// using PA200_webapp.Repository;
//
// namespace PA200_webapp.Services;
//
// public class AdminService: IAdminService
// {
//     private IMapper _mapper;
//     private IUnitOfWork _unitOfWork;
//
//     public AdminService(IMapper mapper, IUnitOfWork unitOfWork)
//     {
//         _mapper = mapper;
//         _unitOfWork = unitOfWork;
//     }
//
//     public SchoolCreatedDTO CreateSchool(CreateSchoolDTO schoolDto)
//     {
//         var x = _unitOfWork.SchoolRepository.createSchool(_mapper.Map<School>(schoolDto));
//         _unitOfWork.Save();
//         return _mapper.Map<SchoolCreatedDTO>(x);
//     }
//
//     public ClassCreatedDto CreateClass(CreateClassDTO classDto)
//     {
//         var classEntity = _unitOfWork.ClassRepository.createClass(_mapper.Map<Class>(classDto));
//         _unitOfWork.Save();
//         return _mapper.Map<ClassCreatedDto>(classEntity);
//     }
//
//     public SubjectCreatedDTO CreateSubject(CreateSubjectDTO subjectDto)
//     {
//         var subjectEntity = _unitOfWork.SubjectRepository.createSubject(_mapper.Map<Subject>(subjectDto));
//         _unitOfWork.Save();
//         return _mapper.Map<SubjectCreatedDTO>(subjectEntity);
//     }
//
//     public GetUsersResponseModel GetUsers()
//     {
//         throw new NotImplementedException();
//         // return new GetUsersResponseModel() { Users = _unitOfWork.UserRepository.FindAll() };
//     }
//
//     public GetClassesResponseModel GetClasses()
//     {
//         throw new NotImplementedException();
//         //return new GetClassesResponseModel() { Classes = _unitOfWork.ClassRepository.FindAll() };
//     }
//
//     public GetSubjectsResponseModel GetSubjects()
//     {
//         throw new NotImplementedException();
//         //return new GetSubjectsResponseModel() { Subjects = _unitOfWork.SubjectRepository.FindAll() };
//     }
// }