namespace University.Application.Modules.Query.CommonResult;

public sealed class ModuleQr
{
    public Guid ModuleId { get; set; }
    public string ModuleName { get; set; }
    public string Code { get; set; }
    public int Capacity { get; set; }
    public string EmployeeName { get; set; }
}