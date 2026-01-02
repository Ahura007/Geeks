using University.Application.Employees.Query.CommonResult;
using University.Application.Employees.Query.GetEmployee;

namespace University.Infra.Query.Employees;

internal sealed class EmployeeQueryService
{
    public List<EmployeeQr> Execute(GetEmployeeQuery query)
    {
        return (from s in DbContext.Employees
            select new EmployeeQr
            {
                EmployeeId = s.Id,
                EmployeeName = s.FullName
            }).ToList();
    }
}