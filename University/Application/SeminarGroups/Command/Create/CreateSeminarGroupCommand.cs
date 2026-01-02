using University.Infra.Core.Enum;

namespace University.Application.SeminarGroups.Command.Create;

public sealed class CreateSeminarGroupCommand
{
    public required Guid ModuleId { get; set; }
    public required DayOfWeek DayOfWeek { get; set; }
    public required TimeSpan StartTime { get; set; }
    public required TimeSpan EndTime { get; set; }
    public required short Capacity { get; set; }
    public required SeminarGroupType SeminarGroupType { get; set; }
    public required string LocationOrLink { get; set; } = string.Empty;
}