using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Repository;
using PA200_webapp.Services;

namespace PA200_webapp.Controllers;

[ApiController]
[Authorize]
[Route("user")]
public class UserController: ControllerBase
{
    private IMapper _mapper;
    private IUserService _userService;

    public UserController(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    [HttpGet]
    [Route("wall")]
    public WallResponseModel GetUserWall()
    {
        try
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            var userEmail = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            return _userService.GetUserWall(userEmail);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}