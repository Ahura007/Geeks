using University.Application.SeminarGroups.Query.CommonResult;
using University.Infra.Application;
using University.Infra.Query.SeminarGroups;

namespace University.Application.SeminarGroups.Query.GetSeminarGroup;

public class GetSeminarGroupQueryHandler
{
    public ApplicationServiceResult<List<SeminarGroupQr>> Handle(GetSeminarGroupQuery query)
    {
        var modules = new SeminarGroupQueryService().Execute(query);
        return new ApplicationServiceResult<List<SeminarGroupQr>>
            { Data = modules, State = ApplicationServiceState.Ok };
    }
}