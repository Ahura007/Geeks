using University.Infra;

namespace University.Domain.Lessons.Aggregate;

internal sealed class Lesson : AggregateRoot<Guid>
{
    private Lesson()
    {
        Title = null!;
    }

    public string Title { get; private set; } = null!;

    public static Lesson Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("عنوان درس نمی‌تواند خالی یا null باشد.", nameof(title));

        title = title.Trim();
        if (title.Length is < 3 or > 200)
            throw new ArgumentException("عنوان درس باید بین ۳ تا ۲۰۰ کاراکتر باشد.", nameof(title));

        return new Lesson
        {
            Title = title,
            Id = Guid.NewGuid()
        };
    }
}