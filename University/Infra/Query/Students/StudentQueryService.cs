using University.Application.Students.Query.CommonResult;
using University.Application.Students.Query.GetStudent;

namespace University.Infra.Query.Students;

internal sealed class StudentQueryService
{
    public List<StudentQr> Execute(GetStudentQuery query)
    {
        return (from s in DbContext.Students
                .OrderBy(x=>x.Priority)
            select new StudentQr
            {
                StudentId = s.Id,
                StudentName = s.FullName
            }).ToList();
    }
}