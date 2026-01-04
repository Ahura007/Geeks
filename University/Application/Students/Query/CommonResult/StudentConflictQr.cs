using University.Infra.Core.Enum;

namespace University.Application.Students.Query.CommonResult;

public sealed class StudentConflictQr
{
    public Guid StudentId { get; init; }
    public string StudentName { get; init; }

    public Guid SeminarGroupId { get; init; }

    public Guid ModuleId { get; init; }
    public string ModuleName { get; init; }

    public ConflictType ConflictType { get; init; }
    public DateTimeOffset ConflictDate { get; init; }

    public string StartTime { get; set; }
    public string EndTime { get; set; }
}