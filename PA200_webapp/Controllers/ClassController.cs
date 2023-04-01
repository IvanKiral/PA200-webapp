using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;
using PA200_webapp.Services;

namespace PA200_webapp.Controllers;

[ApiController]
[Route("class")]
[Authorize]
public class ClassController : ControllerBase
{
    private IMapper _mapper;
    private IClassService _classService;

    public ClassController(IMapper mapper, IClassService classService)
    {
        _mapper = mapper;
        _classService = classService;
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
    [Route("{id:int}/student")]
    public ActionResult<AddStudentToClassSubjectDTO> AddStudentToClass(int id, [FromBody] AddStudentToClassRequestModel model)
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

}