namespace University.Application.Students.Command.AddModuleToStudent;

public sealed class AddModuleToStudentCommand
{
    public required Guid StudentId { get; set; }
    public required List<Guid> ModuleIds { get; set; }
}