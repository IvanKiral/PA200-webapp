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

    public SubjectController(IMapper mapper, ISubjectService subjectService)
    {
        _mapper = mapper;
        _subjectService = subjectService;
    }
    
    [HttpPost]
    [Authorize(Roles = "Teacher")]
    [Route("{id:int}/teacher")]
    public ActionResult<AddStudentToClassSubjectDTO> AddTeacherToClass(int id, [FromBody] AddTeacherToClassRequestModel model)
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
    [Route("{id:int}/student")]
    public ActionResult<AddStudentToClassSubjectDTO> AddStudentToClass(int id, [FromBody] AddStudentToClassRequestModel model)
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
    
    
    [Route("{id:int}/wall")]
    public ActionResult<WallResponseModel> GetClassWall(int id)
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
    [Route("{id:int}/wall/post")]
    public ActionResult<CreatePostResponseModel> AddPostToWall(int id, [FromBody] CreatePostRequestModel model)
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
    [Route("{subjectId:int}/wall/post/{postId:int}")]
    public ActionResult<string> DeletePostFromWall(int subjectId, int postId)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            _subjectService.DeletePost(userEmail, subjectId, postId);
            return Ok("Deleted");
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
        
    }
    
    [HttpPut]
    [Authorize]
    [Route("{subjectId:int}/wall/post/{postId:int}")]
    public ActionResult<UpdatePostResponseModel> UpdatePostWall(int subjectId, int postId, [FromBody] UpdatePostRequestModel model)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var responseModel = _subjectService.UpdatePost(userEmail, postId, _mapper.Map<UpdatePostDTO>(model));
            return Ok(responseModel);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
        
    }
}