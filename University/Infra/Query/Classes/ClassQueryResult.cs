using University.Core.Enum;

namespace University.Infra.Query.Classes;

internal sealed class ClassQueryResult
{
    public Guid LessonId { get; set; }
    public string LessonName { get; set; }
    public Guid ClassId { get; set; }
    public DateTime StartTimeUtc { get; set; }
    public DateTime EndTimeUtc { get; set; }
    public string LocationOrLink { get; set; }
    public ClassType ClassType { get; set; }
    public short Capacity { get; set; }
}