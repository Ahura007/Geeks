using University.Core.Enum;
using University.Domain.Students.Entity;
using University.Infra;

namespace University.Domain.Students.Aggregate;

internal class Student : AggregateRoot<Guid>
{
    private readonly List<Grade> _grades = [];
    private readonly HashSet<StudentClass> _studentClass = [];
    private readonly HashSet<StudentConflict> _studentConflict = [];

    private Student()
    {
    }

    public string FullName { get; private set; }

    public IReadOnlyCollection<Grade> Grades => _grades;

    public IReadOnlyCollection<StudentClass> StudentClass => _studentClass;

    public IReadOnlyCollection<StudentConflict> StudentConflict => _studentConflict;

    public static Student Create(string fullName)
    {
        return new Student
        {
            FullName = fullName,
            Id = Guid.NewGuid()
        };
    }

    public void AddGradeToStudent(Guid lessonId, int grade)
    {
        if (lessonId == Guid.Empty)
            throw new ArgumentException("Invalid lessonId");

        if (grade < 0 || grade > 100)
            throw new ArgumentException("Score must be 0-100");

        var existing = _grades.Any(g => g.LessonId == lessonId);
        if (existing)
            throw new InvalidOperationException("Grade already exists. Use ApplyResit.");

        _grades.Add(new Grade(lessonId, grade));
    }

    public void AddResitGradeToStudent(Guid lessonId, int resitGrade)
    {
        if (lessonId == Guid.Empty)
            throw new ArgumentException("Invalid lessonId");

        var grade = _grades.FirstOrDefault(g => g.LessonId == lessonId);
        if (grade == null)
            throw new InvalidOperationException("No existing grade.");

        grade.AddResitGrade(resitGrade);
    }

    public void AddClassToStudent(Guid classId)
    {
        if (classId == Guid.Empty)
            throw new ArgumentException("Invalid classId");

        if (_studentClass.Any(sc => sc.ClassId == classId))
            throw new InvalidOperationException("Student already register in this class");

        _studentClass.Add(new StudentClass(Id, classId));
    }

    public void AddConflictToStudent(Guid classId, ConflictType conflictType)
    {
        if (classId == Guid.Empty)
            throw new ArgumentException("Invalid classId");

        if (_studentConflict.Any(sc => sc.ClassId == classId && sc.DateTimeOffset == DateTimeOffset.UtcNow))
            throw new InvalidOperationException("Student already have Conflict in this class");

        _studentConflict.Add(new StudentConflict(Id, classId, conflictType));
    }
}