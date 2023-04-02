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
    [Route("{postId:int}/like")]
    public ActionResult LikePost(int postId)
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
    [Route("{postId:int}/like")]
    public ActionResult DeleteLike(int postId)
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
    [Route("{postId:int}/comment")]
    public ActionResult<CreatePostResponseModel> AddComent(int postId, [FromBody] CreatePostRequestModel model)
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
    [Route("{postId:int}")]
    public ActionResult<WallPost> PostDetail(int postId)
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
    
    
}