using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;
using PA200_webapp.Services;

namespace PA200_webapp.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController: ControllerBase
{
    private IUserService _userService;
    private IMapper _mapper;
    
    public RegisterController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult<string> Index([FromBody] RegisterRequestModel model)
    {
        try
        {
            _userService.createUser(_mapper.Map<RegisterUserDTO>(model));
            return Ok("Registered");
        }
        catch(Exception e)
        {
            return StatusCode(500, e);
        }
    }
}