namespace University.Application.Modules.Query.CommonResult;

public sealed class ModuleDto: ModuleQr
{
    public bool IsRegister { get; set; }
    public int RemainingCapacity { get; set; }
    public int TotalCapacity { get; set; }

}