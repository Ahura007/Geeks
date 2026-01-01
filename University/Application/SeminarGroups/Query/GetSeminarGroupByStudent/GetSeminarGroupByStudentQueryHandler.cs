using University.Application.SeminarGroups.Query.CommonResult;
using University.Infra.Application;
using University.Infra.Query.SeminarGroups;

namespace University.Application.SeminarGroups.Query.GetSeminarGroupByStudent;

public class GetSeminarGroupByStudentQueryHandler
{
    public ApplicationServiceResult<List<SeminarGroupQr>> Handle(GetSeminarGroupByStudentQuery query)
    {
        var modules = new SeminarGroupQueryService().Execute(query);
        return new ApplicationServiceResult<List<SeminarGroupQr>>
            { Data = modules, State = ApplicationServiceState.Ok };
    }
}