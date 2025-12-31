using University.Core.Enum;
using University.Infra;

namespace University.Domain.Students.Entity;

internal class StudentConflict : Entity<Guid>
{
    internal StudentConflict(Guid studentId, Guid classId, ConflictType conflictType, DateTimeOffset occurredAt)
    {
        if (studentId == Guid.Empty)
            throw new ArgumentException("StudentId cannot be empty.", nameof(studentId));

        if (classId == Guid.Empty)
            throw new ArgumentException("ClassId cannot be empty.", nameof(classId));

        StudentId = studentId;
        ClassId = classId;
        ConflictType = conflictType;
        OccurredAt = occurredAt;
        Id = Guid.NewGuid();
    }


    internal StudentConflict(Guid studentId, Guid classId, ConflictType conflictType)
        : this(studentId, classId, conflictType, DateTimeOffset.UtcNow)
    {
    }

    public Guid ClassId { get; private set; }

    public Guid StudentId { get; private set; }

    public ConflictType ConflictType { get; private set; }

    public DateTimeOffset OccurredAt { get; private set; }
}