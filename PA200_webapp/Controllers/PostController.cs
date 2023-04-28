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
[Authorize]
[Route("post")]
public class PostController: ControllerBase
{
    private IMapper _mapper;
    private IPostService _postService;

    public PostController(IPostService postService, IMapper mapper)
    {
        _postService = postService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("{postId}/like")]
    public ActionResult LikePost(string postId)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            _postService.LikePost(userEmail, postId);
            return Ok("Liked");
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    [HttpDelete]
    [Route("{postId}/like")]
    public ActionResult DeleteLike(string postId)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            _postService.DeleteLike(userEmail, postId);
            return Ok("Deleted");
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    [HttpPost]
    [Route("{postId}/comment")]
    public ActionResult<CreatePostResponseModel> AddComent(string postId, [FromBody] CreatePostRequestModel model)
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var comment = _postService.CreateComment(userEmail, postId, _mapper.Map<CreatePostDTO>(model));
            return Ok(comment);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    [HttpGet]
    [Route("{postId}")]
    public ActionResult<WallPost> PostDetail(string postId)
    {
        try
        {
            var post = _postService.GetPost(postId);
            return Ok(post);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    [HttpPut]
    [Route("{postId}")]
    public ActionResult<WallPost> UpdatePost(string postId, [FromBody] UpdatePostRequestModel model)
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
    
    [HttpDelete]
    [Route("{postId}")]
    public ActionResult<WallPost> DeletePost(string postId)
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
}