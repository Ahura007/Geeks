namespace University.Infra.Query.StudentConflict;

internal sealed class StudentConflictQueryService
{
    public List<StudentConflictQueryResult> GetClassByStudentId(Guid studentId)
    {
        return (from s in DbContext.Students
            from sc in s.StudentConflict
            join c in DbContext.Classes on sc.ClassId equals c.Id
            join l in DbContext.Lessons on c.LessonId equals l.Id
            where s.Id == studentId
            select new StudentConflictQueryResult
            {
                StudentId = s.Id,
                StudentName = s.FullName,
                ClassId = c.Id,
                LessonId = l.Id,
                LessonTitle = l.Title,
                ConflictType = sc.ConflictType,
                ConflictDate = sc.DateTimeOffset,
                ClassStartUtc = c.StartTimeUtc,
                ClassEndUtc = c.EndTimeUtc
            }).ToList();
    }
}