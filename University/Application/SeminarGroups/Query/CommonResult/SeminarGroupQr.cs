using University.Infra.Core.Enum;

namespace University.Application.SeminarGroups.Query.CommonResult;

public sealed class SeminarGroupQr
{
    public Guid ModuleId { get; set; }
    public string ModuleName { get; set; }
    public Guid SeminarGroupId { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string LocationOrLink { get; set; }
    public SeminarGroupType SeminarGroupType { get; set; }
    public short Capacity { get; set; }
}