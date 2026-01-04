namespace University.Application.Modules.Query.CommonResult;

public   class ModuleQr
{
    public Guid ModuleId { get; set; }
    public string ModuleName { get; set; }
    public string Code { get; set; }
    public int UsedCapacity { get; set; }
    public int RemainingCapacity { get; set; }
    public int TotalCapacity { get; set; }
    public string EmployeeName { get; set; }
}