using System.Data;

namespace University.Infra.Query;

internal sealed class ClassQueryService
{
    public List<ClassQueryResult> GetClass()
    {
        return (from c in DbContext.Classes
                join l in DbContext.Lessons on c.LessonId equals l.Id
                select new ClassQueryResult
                {
                    LessonId = l.Id,
                    LessonName = l.Title,
                    ClassId = c.Id,
                    StartTimeUtc = c.StartTimeUtc.DateTime,
                    EndTimeUtc = c.EndTimeUtc.DateTime,
                    LocationOrLink = c.LocationOrLink,
                    ClassType = c.ClassType,
                    Capacity = c.Capacity
                }).ToList();
    }
}