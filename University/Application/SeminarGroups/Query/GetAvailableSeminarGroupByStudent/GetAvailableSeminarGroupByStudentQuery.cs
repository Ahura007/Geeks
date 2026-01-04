using University.Infra.Core.Enum;

namespace University.Application.SeminarGroups.Query.GetAvailableSeminarGroupByStudent;

public class GetAvailableSeminarGroupByStudentQuery
{
    public Guid StudentId { get; set; }
}

public sealed class SeminarGroupDto
{
    public Guid SeminarGroupId { get; set; }
    public Guid ModuleId { get; set; }

    public string ModuleName { get; set; }
    public SeminarGroupType SeminarGroupType { get; set; }
    public string LocationOrLink { get; set; }

    public int Capacity { get; set; }

    public string StartTime { get; set; }  
    public string EndTime { get; set; } 
    public string DayOfWeek { get; set; }

    public bool IsRegistered { get; set; }
    public int RemainingCapacity { get; set; }
}
