using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Services;

namespace PA200_webapp.Controllers;

[ApiController]
[Route("class")]
[Authorize]
public class ClassController : ControllerBase
{
    private IMapper _mapper;
    private IClassService _classService;
    private IPostService _postService;

    public ClassController(IMapper mapper, IClassService classService, IPostService postService)
    {
        _mapper = mapper;
        _classService = classService;
        _postService = postService;
    }

    [HttpPost]
    [Authorize(Roles = "Teacher")]
    [Route("{id}/teacher")]
    public ActionResult<AddStudentToClassSubjectDTO> AddTeacherToClass(string id, [FromBody] AddTeacherToClassRequestModel model)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var x = _classService.AddTeacherToClass(userEmail, id, _mapper.Map<AddTeacherToClassSubjectDTO>(model));
            return Ok(x);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
        
    }
    
    [HttpPost]
    [Authorize(Roles = "Teacher")]
    [Route("{id}/student")]
    public ActionResult<AddStudentToClassSubjectDTO> AddStudentToClass(string id, [FromBody] AddStudentToClassRequestModel model)
    {
        try
        {
            var x = _classService.AddStudentToClass(id, _mapper.Map<AddStudentToClassSubjectDTO>(model));
            return Ok(x);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
        
    }

    [HttpGet]
    [Route("{id}/wall")]
    public ActionResult<WallResponseModel> GetClassWall(string id)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var wall = _classService.GetClassWall(userEmail, id);
            return Ok(_mapper.Map<WallResponseModel>(wall));
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    [HttpPost]
    [Authorize]
    [Route("{id}/wall/post")]
    public ActionResult<CreatePostResponseModel> AddPostToWall(string id, [FromBody] CreatePostRequestModel model)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var response = _classService.CreatePost(userEmail, id,_mapper.Map<CreatePostDTO>(model));
            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    [HttpDelete]
    [Authorize]
    [Route("{classId}/wall/post/{postId}")]
    public ActionResult<string> DeletePostFromWall(string classId, String postId)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            _postService.DeletePost(userEmail, postId);
            return Ok("Deleted");
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
        
    }
    
    [HttpPut]
    [Authorize]
    [Route("{classId}/wall/post/{postId}")]
    public ActionResult<UpdatePostResponseModel> UpdatePostWall(string classId, string postId, [FromBody] UpdatePostRequestModel model)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var responseModel = _postService.UpdatePost(userEmail, postId, _mapper.Map<UpdatePostDTO>(model));
            return Ok(responseModel);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
        
    }
}