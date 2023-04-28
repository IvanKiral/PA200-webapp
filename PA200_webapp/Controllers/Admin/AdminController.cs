using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Services;
using PA200_webapp.Services.MongoDB;

namespace PA200_webapp.Controllers.Admin;


[ApiController]
[Authorize(Roles="Admin")]
[Route("admin")]
public class AdminController: ControllerBase
{
    private IMapper _mapper;
    private IAdminService _adminService;
    
    public AdminController(
        IMapper mapper,
        IAdminService adminService
    )
    {
        _mapper = mapper;
        _adminService = adminService;
    }
    
    [Authorize(Roles="Admin")]
    [HttpPost]
    [Route("user")]
    public ActionResult<CreateUserResponseModel> CreateUser([FromBody] CreateUserRequestModel model)
    {
        try
        {
            var response = _adminService.createUser(_mapper.Map<CreateUserDTO>(model));
            return Ok(response);
        }
        catch(Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles="Admin")]
    [HttpPost]
    [Route("class")]
    public ActionResult<CreateClassResponseModel> CreateClass([FromBody] CreateClassRequestModel model)
    {
        try
        {
            var entity = _adminService.CreateClass(_mapper.Map<CreateClassDTO>(model));
            return Ok(entity);
        }
        catch(Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles="Admin")]
    [HttpPost]
    [Route("subject")]
    public ActionResult<CreateSubjectResponseModel> CreateSubject([FromBody] CreateSubjectRequestModel model)
    {
        try
        {
            var subjectResponse = _adminService.CreateSubject(_mapper.Map<CreateSubjectDTO>(model));
            return Ok(subjectResponse);
        }
        catch(Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles="Admin")]
    [HttpGet]
    [Route("users")]
    public ActionResult<GetUsersResponseModel> GetUsers()
    {
        try
        {
            var responseModel = _adminService.GetUsers();
            return Ok(responseModel);
        }
        catch(Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    
    [Authorize(Roles="Admin")]
    [HttpGet]
    [Route("class")]
    public ActionResult<GetClassesResponseModel> GetClasses()
    {
        try
        {
            var responseModel = _adminService.GetClasses();
            return Ok(responseModel);
        }
        catch(Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles="Admin")]
    [HttpGet]
    [Route("subject")]
    public ActionResult<GetUsersResponseModel> GetSubjects()
    {
        try
        {
            var responseModel = _adminService.GetSubjects();
            return Ok(responseModel);
        }
        catch(Exception e)
        {
            return StatusCode(500, e);
        }
    }
}