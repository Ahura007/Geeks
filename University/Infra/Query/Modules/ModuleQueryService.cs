using University.Application.Modules.Query.CommonResult;
using University.Application.Modules.Query.GetModules;
using University.Application.Students.Query.GetModuleByStudent;

namespace University.Infra.Query.Modules;

internal sealed class ModuleQueryService
{
    public List<ModuleQr> GetModule(GetModuleQuery query)
    {
        return (from m in DbContext.Modules
            join e in DbContext.Employees on m.EmployeeId equals e.Id
            select new ModuleQr
            {
                ModuleId = m.Id,
                ModuleName = m.Name,
                Capacity = m.Capacity,
                EmployeeName = e.FullName,
                Code = m.Code
            }).ToList();
    }


    public List<ModuleQr> GetModuleByStudentId(GetModuleByStudentIdQuery query)
    {
        return (from s in DbContext.Students
            from sm in s.StudentModule
            join m in DbContext.Modules on sm.StudentId equals query.StudentId
            join e in DbContext.Employees on m.EmployeeId equals e.Id
            select new ModuleQr
            {
                ModuleId = m.Id,
                ModuleName = m.Name,
                Capacity = m.Capacity,
                EmployeeName = e.FullName,
                Code = m.Code
            }).ToList();
    }
}