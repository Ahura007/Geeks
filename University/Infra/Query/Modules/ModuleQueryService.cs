using University.Application.Modules.Query.CommonResult;
using University.Application.Modules.Query.GetModules;
using University.Application.Students.Query.GetModuleByStudent;

namespace University.Infra.Query.Modules;

internal sealed class ModuleQueryService
{
    public List<ModuleQr> GetModule(GetModuleQuery query)
    {
        var registeredCounts = DbContext.Students.SelectMany(x=>x.StudentModule)
            .GroupBy(sm => sm.ModuleId)
            .ToDictionary(g => g.Key, g => g.Count());

        return (from m in DbContext.Modules
            join e in DbContext.Employees on m.EmployeeId equals e.Id
            select new ModuleQr
            {
                ModuleId = m.Id,
                ModuleName = m.Name,
                Code = m.Code,
                EmployeeName = e.FullName,
                TotalCapacity = m.Capacity,
                RemainingCapacity = m.Capacity - registeredCounts.GetValueOrDefault(m.Id, 0),
                UsedCapacity =  registeredCounts.GetValueOrDefault(m.Id, 0),
            }).ToList();
    }


    public List<ModuleQr> GetModuleByStudentId(GetModuleByStudentIdQuery query)
    {
        var students = DbContext.Students.AsQueryable();
        var studentModules = DbContext.Students.SelectMany(x => x.StudentModule).AsQueryable();
        var modules = DbContext.Modules.AsQueryable();
        var employee = DbContext.Employees.AsQueryable();
        var registeredCounts = DbContext.Students.SelectMany(x => x.StudentModule)
            .GroupBy(sm => sm.ModuleId)
            .ToDictionary(g => g.Key, g => g.Count());

        return (from s in students
                join sm in studentModules on s.Id equals sm.StudentId
                join m in modules on sm.ModuleId equals m.Id
                join e in employee on m.EmployeeId equals e.Id
                where s.Id == query.StudentId
                select new ModuleQr
                {
                    ModuleId = m.Id,
                    ModuleName = m.Name,
                    TotalCapacity = m.Capacity,
                    EmployeeName = e.FullName,
                    Code = m.Code,
                    RemainingCapacity = m.Capacity - registeredCounts.GetValueOrDefault(m.Id, 0)
                }).ToList();
    }
}