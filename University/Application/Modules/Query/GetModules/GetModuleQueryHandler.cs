using University.Application.Modules.Query.CommonResult;
using University.Infra.Application;
using University.Infra.Query.Modules;

namespace University.Application.Modules.Query.GetModules;

public class GetModuleQueryHandler
{
    public ApplicationServiceResult<List<ModuleQr>> Handle(GetModuleQuery query)
    {
        var modules = new ModuleQueryService().GetModule(query);
        return new ApplicationServiceResult<List<ModuleQr>> { Data = modules, State = ApplicationServiceState.Ok };
    }
}