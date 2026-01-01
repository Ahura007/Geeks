using University.Application.Students.Query.CommonResult;
using University.Application.Students.Query.GetStudentConflict;

namespace University.Infra.Query.StudentConflict;

internal sealed class StudentConflictQueryService
{
    public List<StudentConflictQr> Execute(GetStudentConflictQuery query)
    {
        return (from s in DbContext.Students
            from sc in s.StudentConflict
            join c in DbContext.SeminarGroups on sc.SeminarGroupId equals c.Id
            join l in DbContext.Modules on c.ModuleId equals l.Id
            where s.Id == query.StudentId
            select new StudentConflictQr
            {
                StudentId = s.Id,
                StudentName = s.FullName,
                SeminarGroupId = c.Id,
                ModuleId = l.Id,
                ModuleName = l.Name,
                ConflictType = sc.ConflictType,

                StartTime = c.StartTime,
                EndTime = c.EndTime
            }).ToList();
    }
}