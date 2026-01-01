using University.Application.SeminarGroups.Query.CommonResult;
using University.Application.SeminarGroups.Query.GetSeminarGroup;
using University.Application.SeminarGroups.Query.GetSeminarGroupByStudent;

namespace University.Infra.Query.SeminarGroups;

internal sealed class SeminarGroupQueryService
{
    public List<SeminarGroupQr> Execute(GetSeminarGroupQuery query)
    {
        return (from c in DbContext.SeminarGroups
            join l in DbContext.Modules on c.ModuleId equals l.Id
            select new SeminarGroupQr
            {
                ModuleId = l.Id,
                ModuleName = l.Name,
                SeminarGroupId = c.Id,
                StartTime = c.StartTime,
                EndTime = c.EndTime,
                LocationOrLink = c.LocationOrLink,
                SeminarGroupType = c.SeminarGroupType,
                Capacity = c.Capacity
            }).ToList();
    }

    public List<SeminarGroupQr> Execute(GetSeminarGroupByStudentQuery query)
    {
        return (from c in DbContext.SeminarGroups
            join l in DbContext.Modules on c.ModuleId equals l.Id
            from sc in DbContext.Students.SelectMany(s => s.StudentClass)
            where sc.SeminarGroupId == c.Id && sc.StudentId == query.StudentId
            select new SeminarGroupQr
            {
                ModuleId = l.Id,
                ModuleName = l.Name,
                SeminarGroupId = c.Id,
                StartTime = c.StartTime,
                EndTime = c.EndTime,
                LocationOrLink = c.LocationOrLink,
                SeminarGroupType = c.SeminarGroupType,
                Capacity = c.Capacity
            }).ToList();
    }
}