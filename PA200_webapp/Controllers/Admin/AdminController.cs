using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Services;

namespace PA200_webapp.Controllers.Admin;


[ApiController]
[Authorize(Roles="Admin")]
[Route("admin")]
public class AdminController: ControllerBase
{
    private IUserService _userService;
    private IMapper _mapper;
    private IAdminService _adminService;
    
    public AdminController(
        IMapper mapper, 
        IUserService userService,
        IAdminService adminService
    )
    {
        _userService = userService;
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
            var response = _userService.createUser(_mapper.Map<CreateUserDTO>(model));
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
    [HttpPost]
    [Route("school")]
    public ActionResult<CreateSchoolResponseModel> CreateSchool([FromBody] CreateSchoolRequestModel model)
    {
        try
        {
            var responseModel = _adminService.CreateSchool(_mapper.Map<CreateSchoolDTO>(model));
            return Ok(responseModel);
        }
        catch(Exception e)
        {
            return StatusCode(500, e);
        }
    }
}