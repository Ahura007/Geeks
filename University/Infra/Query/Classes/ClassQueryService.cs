namespace University.Infra.Query.Classes;

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

    public List<ClassQueryResult> GetClassByStudentId(Guid studentId)
    {
        return (from c in DbContext.Classes
            join l in DbContext.Lessons on c.LessonId equals l.Id
            from sc in DbContext.Students.SelectMany(s => s.StudentClass)
            where sc.ClassId == c.Id && sc.StudentId == studentId
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