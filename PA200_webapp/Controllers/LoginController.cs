using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PA200_webapp.Infrastructure;
using PA200_webapp.models.ResponseModels;

namespace PA200_webapp.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController: ControllerBase
{
    private IUnitOfWork _unitOfWork;
    private IAuthService _authService;
    
    public LoginController(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public class LoginBody
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
    [HttpPost]
    public ActionResult<LoginResponseModel> Index([FromBody] LoginBody loginBody)
    {
        var user = _unitOfWork.UserRepository
            .FindByCondition(u => u.Email == loginBody.Email && u.PasswordHash == loginBody.Password)
            .FirstOrDefault();
        if (user == null)
        {
            return Unauthorized();
        }

        var token = _authService.generateToken(user);
        return new LoginResponseModel() { Token = token };
    }
}