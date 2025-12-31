using University.Core.Enum;
using University.Infra;

namespace University.Domain.Students.Entity;

internal class StudentConflict : Entity<Guid>
{
    internal StudentConflict(Guid studentId, Guid classId, ConflictType conflictType)
    {
        StudentId = studentId;
        ClassId = classId;
        ConflictType = conflictType;
        Id = Guid.NewGuid();
        DateTimeOffset = DateTimeOffset.UtcNow;
    }

    public Guid ClassId { get; private set; }
    public Guid StudentId { get; private set; }
    public ConflictType ConflictType { get; private set; }
    public DateTimeOffset DateTimeOffset { get; }
}