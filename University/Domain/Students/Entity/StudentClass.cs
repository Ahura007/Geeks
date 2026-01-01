using University.Infra.Domain;

namespace University.Domain.Students.Entity;

internal class StudentClass : Entity<Guid>
{
    internal StudentClass(Guid studentId, Guid seminarGroupId)
    {
        if (studentId == Guid.Empty)
            throw new ArgumentException("StudentId cannot be empty.", nameof(studentId));

        if (seminarGroupId == Guid.Empty)
            throw new ArgumentException("seminarGroup cannot be empty.", nameof(seminarGroupId));

        StudentId = studentId;
        SeminarGroupId = seminarGroupId;
        Id = Guid.NewGuid();
    }

    public Guid SeminarGroupId { get; private set; }
    public Guid StudentId { get; private set; }
}