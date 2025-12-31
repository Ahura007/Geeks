using University.Core.Enum;

namespace University.Infra.Query.StudentConflict;

internal sealed class StudentConflictQueryResult
{
    public Guid StudentId { get; init; }
    public string StudentName { get; init; }

    public Guid ClassId { get; init; }

    public Guid LessonId { get; init; }
    public string LessonTitle { get; init; }

    public ConflictType ConflictType { get; init; }
    public DateTimeOffset ConflictDate { get; init; }

    public DateTimeOffset ClassStartUtc { get; init; }
    public DateTimeOffset ClassEndUtc { get; init; }
}