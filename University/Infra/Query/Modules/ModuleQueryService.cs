using University.Application.Modules.Query.CommonResult;
using University.Application.Modules.Query.GetModules;
using University.Application.Students.Query.GetModuleByStudent;

namespace University.Infra.Query.Modules;

internal sealed class ModuleQueryService
{
    public List<ModuleQr> GetModule(GetModuleQuery query)
    {
        return DbContext.Modules.Select(x => new ModuleQr
        {
            ModuleId = x.Id,
            ModuleName = x.Name
        }).ToList();
    }


    public List<ModuleQr> GetModuleByStudentId(GetModuleByStudentIdQuery query)
    {
        return (from s in DbContext.Students
            from sm in s.StudentModule
            join m in DbContext.Modules
                on sm.StudentId equals query.StudentId
            select new ModuleQr
            {
                ModuleId = m.Id,
                ModuleName = m.Name
            }).ToList();
    }
}