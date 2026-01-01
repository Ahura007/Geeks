using University.Application.Students.Query.CommonResult;
using University.Infra.Application;
using University.Infra.Query.Students;

namespace University.Application.Students.Query.GetStudent;

public class GetStudentQueryHandler
{
    public ApplicationServiceResult<List<StudentQr>> Handle(GetStudentQuery query)
    {
        var modules = new StudentQueryService().Execute(query);
        return new ApplicationServiceResult<List<StudentQr>> { Data = modules, State = ApplicationServiceState.Ok };
    }
}