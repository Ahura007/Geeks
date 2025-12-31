using University.Infra;

namespace University.Domain.Students.Entity;

internal class StudentClass : Entity<Guid>
{
    internal StudentClass(Guid studentId, Guid classId)
    {
        StudentId = studentId;
        ClassId = classId;
        Id = Guid.NewGuid();
    }

    public Guid ClassId { get; private set; }
    public Guid StudentId { get; private set; }
}