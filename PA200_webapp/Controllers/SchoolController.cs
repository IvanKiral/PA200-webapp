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
    
    [HttpGet]
    [Route("school/wall")]
    public ActionResult<WallResponseModel> GetSchoolWall()
    {
        var currentUser = HttpContext.User.Identity as ClaimsIdentity;
        var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

        return _mapper.Map<WallResponseModel>(_schoolService.GetSchoolWall(userEmail));
    }

    [HttpPost]
    [Authorize(Roles ="Teacher, Admin")]
    [Route("school/wall/post")]
    public ActionResult<CreatePostResponseModel> AddPostToWall([FromBody] CreatePostRequestModel model)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var response = _schoolService.CreatePost(userEmail,_mapper.Map<CreatePostDTO>(model));
            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
        
    }
    
}