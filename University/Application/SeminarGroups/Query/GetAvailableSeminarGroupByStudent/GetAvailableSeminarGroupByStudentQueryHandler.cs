using University.Application.SeminarGroups.Query.CommonResult;
using University.Application.SeminarGroups.Query.GetSeminarGroupByStudent;
using University.Infra.Application;
using University.Infra.Query.SeminarGroups;

namespace University.Application.SeminarGroups.Query.GetAvailableSeminarGroupByStudent;

public class GetAvailableSeminarGroupByStudentQueryHandler
{
    public ApplicationServiceResult<List<SeminarGroupQr>> Handle(GetAvailableSeminarGroupByStudentQuery query)
    {
        var modules = new SeminarGroupQueryService().Execute(query);
        return new ApplicationServiceResult<List<SeminarGroupQr>>
            { Data = modules, State = ApplicationServiceState.Ok };
    }
}