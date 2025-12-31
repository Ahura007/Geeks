using University.Core.Enum;
using University.Infra;

namespace University.Domain.SeminarGroups.Aggregate;

internal sealed class SeminarGroup : AggregateRoot<Guid>
{
    private SeminarGroup()
    {
    }

    public Guid LessonId { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }
    public short Capacity { get; private set; }
    public ClassType ClassType { get; private set; }
    public string LocationOrLink { get; private set; } = string.Empty;

    public static SeminarGroup Create(Guid lessonId, DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime,
        short capacity, ClassType classType, string locationOrLink)
    {
        if (lessonId == Guid.Empty)
            throw new ArgumentException("LessonId cannot be empty.", nameof(lessonId));

        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero.", nameof(capacity));

        if (startTime >= endTime)
            throw new ArgumentException("End time must be after start time.");

        if (startTime < TimeSpan.Zero || startTime >= TimeSpan.FromDays(1))
            throw new ArgumentException("Start time must be between 00:00 and 23:59.");

        if (endTime <= TimeSpan.Zero || endTime > TimeSpan.FromDays(1))
            throw new ArgumentException("End time must be between 00:00 and 24:00.");

        if (string.IsNullOrWhiteSpace(locationOrLink))
            throw new ArgumentException("Location or link is required.", nameof(locationOrLink));

        if (classType == ClassType.Virtual && !IsValidUrl(locationOrLink))
            throw new ArgumentException("Invalid URL for virtual class.", nameof(locationOrLink));

        return new SeminarGroup
        {
            Id = Guid.NewGuid(),
            LessonId = lessonId,
            DayOfWeek = dayOfWeek,
            StartTime = startTime,
            EndTime = endTime,
            Capacity = capacity,
            ClassType = classType,
            LocationOrLink = locationOrLink
        };
    }

    private static bool IsValidUrl(string locationOrLink)
    {
        return Uri.TryCreate(locationOrLink, UriKind.Absolute, out var uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }

    public bool OverlapsWith(SeminarGroup other)
    {
        if (DayOfWeek != other.DayOfWeek) return false;
        return StartTime < other.EndTime && other.StartTime < EndTime;
    }
}