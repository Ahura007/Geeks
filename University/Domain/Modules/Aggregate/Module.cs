using University.Infra.Domain;

namespace University.Domain.Modules.Aggregate;

internal sealed class Module : AggregateRoot<Guid>
{
    private Module()
    {
    }

    public string Code { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public int Capacity { get; private set; }
    public Guid EmployeeId { get; private set; }

    public static Module Create(string code, string name, int capacity, Guid employeeId)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("کد ماژول نمی‌تواند خالی یا null باشد.", nameof(code));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("عنوان ماژول نمی‌تواند خالی یا null باشد.", nameof(name));

        code = code.Trim().ToUpper();
        if (code.Length is < 3 or > 20)
            throw new ArgumentException("کد ماژول باید بین ۳ تا ۲۰ کاراکتر باشد.", nameof(code));

        name = name.Trim();
        if (name.Length is < 3 or > 200)
            throw new ArgumentException("عنوان ماژول باید بین ۳ تا ۲۰۰ کاراکتر باشد.", nameof(name));

        if (capacity <= 0)
            throw new ArgumentException("ظرفیت ماژول باید بزرگ‌تر از صفر باشد.", nameof(capacity));

        if (employeeId == Guid.Empty)
            throw new ArgumentException("شناسه استاد مسئول نمی‌تواند خالی باشد.", nameof(employeeId));

        return new Module
        {
            Id = Guid.NewGuid(),
            Code = code,
            Name = name,
            Capacity = capacity,
            EmployeeId = employeeId
        };
    }
}