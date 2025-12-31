using University.Domain.Students.Entity;
using University.Infra;

namespace University.Domain.Students.Aggregate;

internal class Student : AggregateRoot<Guid>
{
    private Student()
    {
    }

    public string FullName { get; private set; }

    public IReadOnlyCollection<Grade> Grades => _grades;
    private readonly List<Grade> _grades = new();

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
        if (grade < 0 || grade > 100)
            throw new ArgumentException("Score must be 0-100");

        var existing = _grades.Any(g => g.LessonId == lessonId);
        if (existing)
            throw new InvalidOperationException("Grade already exists. Use ApplyResit.");

        _grades.Add(new Grade(lessonId, grade));
    }

    public void AddResitGradeToStudent(Guid lessonId, int resitGrade)
    {
        var grade = _grades.FirstOrDefault(g => g.LessonId == lessonId);
        if (grade == null)
            throw new InvalidOperationException("No existing grade.");

        grade.AddResitGrade(resitGrade);
    }
}