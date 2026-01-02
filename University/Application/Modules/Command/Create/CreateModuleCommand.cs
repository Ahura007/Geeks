namespace University.Application.Modules.Command.Create;

public sealed class CreateModuleCommand
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required int Capacity { get; set; }
    public required Guid ResponsibleStaffId { get; set; }
}