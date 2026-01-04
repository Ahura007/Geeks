using University.Application.SeminarGroups.Query.CommonResult;
using University.Application.SeminarGroups.Query.GetAvailableSeminarGroupByStudent;
using University.Application.SeminarGroups.Query.GetSeminarGroup;
using University.Application.SeminarGroups.Query.GetSeminarGroupByStudent;

namespace University.Infra.Query.SeminarGroups;

internal sealed class SeminarGroupQueryService
{
    public List<SeminarGroupQr> Execute(GetSeminarGroupQuery query)
    {
        var registeredCounts = DbContext.Students
            .SelectMany(s => s.StudentSeminarGroup)
            .GroupBy(ssg => ssg.SeminarGroupId)
            .ToDictionary(g => g.Key, g => g.Count());

        return (
            from c in DbContext.SeminarGroups
            join l in DbContext.Modules on c.ModuleId equals l.Id
            select new SeminarGroupQr
            {
                ModuleId = l.Id,
                ModuleName = l.Name,
                SeminarGroupId = c.Id,
                StartTime = c.StartTime.ToString("hh\\:mm"),
                EndTime = c.EndTime.ToString("hh\\:mm"),
                LocationOrLink = c.LocationOrLink,
                SeminarGroupType = c.SeminarGroupType,
                Capacity = c.Capacity,
                DayOfWeek = c.DayOfWeek,
                RemainingCapacity = c.Capacity - registeredCounts.GetValueOrDefault(c.Id, 0),
                ModuleCapacity = l.Capacity
            }).ToList();
    }

    public List<SeminarGroupQr> Execute(GetAvailableSeminarGroupByStudentQuery query)
    {
        var registeredCounts = DbContext.Students
            .SelectMany(s => s.StudentSeminarGroup)
            .GroupBy(ssg => ssg.SeminarGroupId)
            .ToDictionary(g => g.Key, g => g.Count());

        return (
            from studentModule in DbContext.Students
                .Where(s => s.Id == query.StudentId)
                .SelectMany(s => s.StudentModule)

            join module in DbContext.Modules on studentModule.ModuleId equals module.Id
            join seminarGroup in DbContext.SeminarGroups on module.Id equals seminarGroup.ModuleId

            select new SeminarGroupQr
            {
                SeminarGroupId = seminarGroup.Id,
                ModuleId = module.Id,
                ModuleName = module.Name,
                DayOfWeek = seminarGroup.DayOfWeek,
                StartTime = seminarGroup.StartTime.ToString("hh\\:mm"),
                EndTime = seminarGroup.EndTime.ToString("hh\\:mm"),
                Capacity = seminarGroup.Capacity,
                SeminarGroupType = seminarGroup.SeminarGroupType,
                LocationOrLink = seminarGroup.LocationOrLink,
                RemainingCapacity = seminarGroup.Capacity - registeredCounts.GetValueOrDefault(seminarGroup.Id, 0)
            }
        ).ToList();
    }

    public List<SeminarGroupQr> Execute(GetSeminarGroupByStudentQuery query)
    {
        var registeredCounts = DbContext.Students
            .SelectMany(s => s.StudentSeminarGroup)
            .GroupBy(ssg => ssg.SeminarGroupId)
            .ToDictionary(g => g.Key, g => g.Count());

        return (
            from studentSeminar in DbContext.Students
                .Where(s => s.Id == query.StudentId)
                .SelectMany(s => s.StudentSeminarGroup)

            join seminarGroup in DbContext.SeminarGroups on studentSeminar.SeminarGroupId equals seminarGroup.Id
            join module in DbContext.Modules on seminarGroup.ModuleId equals module.Id

            select new SeminarGroupQr
            {
                SeminarGroupId = seminarGroup.Id,
                ModuleId = module.Id,
                ModuleName = module.Name,
                DayOfWeek = seminarGroup.DayOfWeek,
                StartTime = seminarGroup.StartTime.ToString("hh\\:mm"),
                EndTime = seminarGroup.EndTime.ToString("hh\\:mm"),
                Capacity = seminarGroup.Capacity,
                SeminarGroupType = seminarGroup.SeminarGroupType,
                LocationOrLink = seminarGroup.LocationOrLink,
                RemainingCapacity = seminarGroup.Capacity - registeredCounts.GetValueOrDefault(seminarGroup.Id, 0)
            }
        ).ToList();
    }
}