using University.Core.Enum;
using University.Infra;

namespace University.Domain.Classes.Aggregate;

internal class Class : AggregateRoot<Guid>
{
    private Class()
    {
    }

    public Guid LessonId { get; private set; }
    public DateTimeOffset StartTimeUtc { get; private set; }
    public DateTimeOffset EndTimeUtc { get; private set; }
    public string LocationOrLink { get; private set; }
    public ClassType ClassType { get; private set; }
    public short Capacity { get; private set; }

    public static Class Create(Guid lessonId, DateTimeOffset startTimeUtc, DateTimeOffset endTimeUtc, short capacity,
        ClassType classType, string locationOrLink)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero.");

        if (endTimeUtc <= startTimeUtc)
            throw new ArgumentException("Invalid time range.");

        if (string.IsNullOrWhiteSpace(locationOrLink))
            throw new ArgumentException("Location or link is required.");

        if (classType == ClassType.Virtual)
            ValidateLink(locationOrLink);

        return new Class
        {
            Id = Guid.NewGuid(),
            LessonId = lessonId,
            StartTimeUtc = startTimeUtc,
            EndTimeUtc = endTimeUtc,
            Capacity = capacity,
            ClassType = classType,
            LocationOrLink = locationOrLink
        };
    }

    private static void ValidateLink(string locationOrLink)
    {
        if (!Uri.TryCreate(locationOrLink, UriKind.Absolute, out var uri))
            throw new ArgumentException("link is Invalid.");
    }
}