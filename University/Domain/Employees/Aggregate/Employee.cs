using University.Infra.Domain;

namespace University.Domain.Employees.Aggregate;

internal class Employee : AggregateRoot<Guid>
{
    private Employee()
    {
    }

    public string FullName { get; private set; }
    public long Priority { get; private set; }

    public static Employee Create(string fullName)
    {
      
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("نام دانشجو نمی‌تواند خالی باشد.", nameof(fullName));

        fullName = fullName.Trim();

        if (fullName.Length is < 3 or > 100)
            throw new ArgumentException("نام دانشجو باید بین ۳ تا ۱۰۰ کاراکتر باشد.", nameof(fullName));

        return new Employee
        {
            FullName = fullName,
            Id = Guid.NewGuid(),
            Priority = DateTimeOffset.Now.ToUnixTimeMilliseconds()
        };
    }
}