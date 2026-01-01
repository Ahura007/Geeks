using University.Infra.Core.Enum;
using University.Infra.Domain;

namespace University.Domain.Students.Entity;

internal class StudentConflict : Entity<Guid>
{
    internal StudentConflict(Guid studentId, Guid seminarGroupId, ConflictType conflictType, DateTimeOffset occurredAt)
    {
        if (studentId == Guid.Empty)
            throw new ArgumentException("StudentId cannot be empty.", nameof(studentId));

        if (seminarGroupId == Guid.Empty)
            throw new ArgumentException("SeminarGroupId cannot be empty.", nameof(seminarGroupId));

        StudentId = studentId;
        SeminarGroupId = seminarGroupId;
        ConflictType = conflictType;
        OccurredAt = occurredAt;
        Id = Guid.NewGuid();
    }


    internal StudentConflict(Guid studentId, Guid seminarGroupId, ConflictType conflictType)
        : this(studentId, seminarGroupId, conflictType, DateTimeOffset.UtcNow)
    {
    }

    public Guid SeminarGroupId { get; private set; }

    public Guid StudentId { get; private set; }

    public ConflictType ConflictType { get; private set; }

    public DateTimeOffset OccurredAt { get; private set; }
}