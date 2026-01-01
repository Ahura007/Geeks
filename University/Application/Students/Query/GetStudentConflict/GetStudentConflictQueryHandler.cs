using University.Application.Students.Query.CommonResult;
using University.Infra.Application;
using University.Infra.Query.StudentConflict;

namespace University.Application.Students.Query.GetStudentConflict;

public class GetStudentConflictQueryHandler
{
    public ApplicationServiceResult<List<StudentConflictQr>> Handle(GetStudentConflictQuery query)
    {
        var modules = new StudentConflictQueryService().Execute(query);
        return new ApplicationServiceResult<List<StudentConflictQr>>
            { Data = modules, State = ApplicationServiceState.Ok };
    }
}