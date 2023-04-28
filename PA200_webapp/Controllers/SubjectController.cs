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
[Route("subject")]
[Authorize]
public class SubjectController: ControllerBase
{
    private IMapper _mapper;
    private ISubjectService _subjectService;
    private IPostService _postService;

    public SubjectController(IMapper mapper, ISubjectService subjectService, IPostService postService)
    {
        _mapper = mapper;
        _subjectService = subjectService;
        _postService = postService;
    }
    
    [HttpPost]
    [Authorize(Roles = "Teacher")]
    [Route("{id}/teacher")]
    public ActionResult<AddStudentToClassSubjectDTO> AddTeacherToSubject(string id, [FromBody] AddTeacherToClassRequestModel model)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var x = _subjectService.AddTeacherToSubject(userEmail, id, _mapper.Map<AddTeacherToClassSubjectDTO>(model));
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
    public ActionResult<AddStudentToClassSubjectDTO> AddStudentToSubject(string id, [FromBody] AddStudentToClassRequestModel model)
    {
        try
        {
            var x = _subjectService.AddStudentToSubject(id, _mapper.Map<AddStudentToClassSubjectDTO>(model));
            return Ok(x);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
        
    }
    
    [HttpGet]
    [Route("{id}/wall")]
    public ActionResult<WallResponseModel> GetSubjectWall(string id)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var wall = _subjectService.GetSubjectWall(userEmail, id);
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
            var response = _subjectService.CreatePost(userEmail, id,_mapper.Map<CreatePostDTO>(model));
            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    [HttpDelete]
    [Authorize]
    [Route("{subjectId}/wall/post/{postId}")]
    public ActionResult<string> DeletePostFromWall(string subjectId, string postId)
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
    [Route("{subjectId}/wall/post/{postId}")]
    public ActionResult<UpdatePostResponseModel> UpdatePostWall(string subjectId, string postId, [FromBody] UpdatePostRequestModel model)
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