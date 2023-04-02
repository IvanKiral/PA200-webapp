using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PA200_webapp.Infrastructure;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;
using PA200_webapp.models.ResponseModels;
using PA200_webapp.Services;
using Mapper = PA200_webapp.Infrastructure.Mapper;

namespace PA200_webapp.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController: ControllerBase
{
    private IUserService _userService;
    private IAuthService _authService;
    private IMapper _mapper;
    
    public LoginController(IUserService userService, IAuthService authService, IMapper mapper)
    {
        _userService = userService;
        _authService = authService;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult<LoginResponseModel> Index([FromBody] LoginUserRequest request)
    {
        var user = _userService.authenticateUser(_mapper.Map<LoginUserDTO>(request));
        if (user == null)
        {
            return Unauthorized();
        }

        var token = _authService.generateToken(user);
        return new LoginResponseModel() { Token = token };
    }
}