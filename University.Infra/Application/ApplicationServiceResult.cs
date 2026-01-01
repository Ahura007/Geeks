namespace University.Infra.Application;

public sealed class ApplicationServiceResult
{
    public string Message { get; set; }
    public required ApplicationServiceState State { get; set; }
}

public sealed class ApplicationServiceResult<T>
{
    public string Message { get; set; }
    public required ApplicationServiceState State { get; set; }
    public T Data { get; set; }
}