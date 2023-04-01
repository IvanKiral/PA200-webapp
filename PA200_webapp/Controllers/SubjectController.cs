using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PA200_webapp.models.DTO;
using PA200_webapp.models.RequestModels;
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
}