using University.Infra.Core.Enum;

namespace University.Application.SeminarGroups.Query.CommonResult;

public sealed class SeminarGroupQr
{
    public Guid ModuleId { get; set; }
    public string ModuleName { get; set; }
    public Guid SeminarGroupId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string LocationOrLink { get; set; }
    public SeminarGroupType SeminarGroupType { get; set; }
    public short Capacity { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int RemainingCapacity { get; set; }
    public int ModuleCapacity { get; set; }
    public int UsedCapacity { get; set; }
    public int ModuleUsedCapacity { get; set; }
}