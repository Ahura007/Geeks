using University.Infra;

namespace University.Domain.Lessons.Aggregate;

internal class Lesson : AggregateRoot<Guid>
{
    private Lesson()
    {
    }


    public string Title { get; private set; }


    public static Lesson Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title required");

        return new Lesson
        {
            Title = title,
            Id = Guid.NewGuid()
        };
    }
}