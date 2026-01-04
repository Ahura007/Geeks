using University.Infra.Domain;

namespace University.Domain.Students.Entity;

internal sealed class StudentModule : Entity<Guid>
{
    internal StudentModule(Guid studentId, Guid moduleId)
    {
        StudentId = studentId;
        ModuleId = moduleId;
        Id= Guid.NewGuid();
    }

    public Guid StudentId { get; private set; }
    public Guid ModuleId { get; private set; }
}