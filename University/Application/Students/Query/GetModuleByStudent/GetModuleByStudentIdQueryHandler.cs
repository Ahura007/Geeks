using University.Application.Modules.Query.CommonResult;
using University.Infra.Application;
using University.Infra.Query.Modules;

namespace University.Application.Students.Query.GetModuleByStudent;

public sealed class GetModuleByStudentIdQueryHandler
{
    public ApplicationServiceResult<List<ModuleQr>> Handle(GetModuleByStudentIdQuery query)
    {
        var modules = new ModuleQueryService().GetModuleByStudentId(query);
        return new ApplicationServiceResult<List<ModuleQr>> { Data = modules, State = ApplicationServiceState.Ok };
    }
}