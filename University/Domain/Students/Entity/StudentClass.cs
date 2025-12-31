using University.Infra;

namespace University.Domain.Students.Entity;

internal class StudentClass : Entity<Guid>
{
    internal StudentClass(Guid studentId, Guid classId)
    {
        if (studentId == Guid.Empty)
            throw new ArgumentException("StudentId cannot be empty.", nameof(studentId));

        if (classId == Guid.Empty)
            throw new ArgumentException("ClassId cannot be empty.", nameof(classId));

        StudentId = studentId;
        ClassId = classId;
        Id = Guid.NewGuid();
    }

    public Guid ClassId { get; private set; }
    public Guid StudentId { get; private set; }
}