using University.Infra.Domain;

namespace University.Domain.Modules.Aggregate;

internal sealed class Module : AggregateRoot<Guid>
{
    private Module()
    {
    }

    public string Name { get; private set; } = null!;

    public static Module Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("عنوان درس نمی‌تواند خالی یا null باشد.", nameof(name));

        name = name.Trim();
        if (name.Length is < 3 or > 200)
            throw new ArgumentException("عنوان درس باید بین ۳ تا ۲۰۰ کاراکتر باشد.", nameof(name));

        return new Module
        {
            Name = name,
            Id = Guid.NewGuid()
        };
    }
}