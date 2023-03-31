using PA200_webapp.models.DTO;
using PA200_webapp.models.DTO.Create;

namespace PA200_webapp.Services;

public interface IAdminService
{
    public SchoolCreatedDTO CreateSchool(CreateSchoolDTO schoolDto);
    public ClassCreatedDto CreateClass(CreateClassDTO classDto);
    public SubjectCreatedDTO CreateSubject(CreateSubjectDTO subjectDto);

}