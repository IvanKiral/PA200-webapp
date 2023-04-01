using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PA200_webapp.models;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Repository;
using PA200_webapp.Services;

namespace PA200_webapp.Controllers;

[ApiController]
[Authorize]
public class SchoolController: ControllerBase
{
    private ISchoolService _schoolService;
    private IMapper _mapper;
    
    public SchoolController(IMapper mapper,ISchoolService schoolService)
    {
        _mapper = mapper;
        _schoolService = schoolService;
    }
    
    
    [Route("school/wall")]
    public ActionResult<SchoolWallResponseModel> GetSchoolWall()
    {
        var currentUser = HttpContext.User.Identity as ClaimsIdentity;
        var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

        return _mapper.Map<SchoolWallResponseModel>(_schoolService.GetSchoolWall(userEmail));
    }

    [HttpPost]
    [Authorize(Roles ="Teacher, Admin")]
    [Route("school/post")]
    public ActionResult<string> AddPostToWall([FromBody] CreatePostOnSchoolWallRequestModel model)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            _schoolService.CreatePost(userEmail,_mapper.Map<CreatePostOnSchoolWallDTO>(model));
            return Ok("Created");
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
        
    }
    
}