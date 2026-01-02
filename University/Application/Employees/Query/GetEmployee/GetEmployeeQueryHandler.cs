using University.Application.Employees.Query.CommonResult;
using University.Infra.Application;
using University.Infra.Query.Employees;

namespace University.Application.Employees.Query.GetEmployee;

public class GetEmployeeQueryHandler
{
    public ApplicationServiceResult<List<EmployeeQr>> Handle(GetEmployeeQuery query)
    {
        var modules = new EmployeeQueryService().Execute(query);
        return new ApplicationServiceResult<List<EmployeeQr>> { Data = modules, State = ApplicationServiceState.Ok };
    }
}