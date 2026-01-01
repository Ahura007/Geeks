using University.Domain.Students.Entity;
using University.Infra.Core.Enum;
using University.Infra.Domain;

namespace University.Domain.Students.Aggregate;

internal class Student : AggregateRoot<Guid>
{
    private readonly List<Grade> _grades = [];
    private readonly HashSet<StudentClass> _studentClass = [];
    private readonly HashSet<StudentConflict> _studentConflict = [];
    private readonly HashSet<StudentModule> _studentModule = [];


    private Student()
    {
    }

    public string FullName { get; private set; }
    public IReadOnlyCollection<Grade> Grades => _grades;
    public IReadOnlyCollection<StudentClass> StudentClass => _studentClass;
    public IReadOnlyCollection<StudentConflict> StudentConflict => _studentConflict;
    public IReadOnlyCollection<StudentModule> StudentModule => _studentModule;

    public static Student Create(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("نام دانشجو نمی‌تواند خالی باشد.", nameof(fullName));

        fullName = fullName.Trim();

        if (fullName.Length is < 3 or > 100)
            throw new ArgumentException("نام دانشجو باید بین ۳ تا ۱۰۰ کاراکتر باشد.", nameof(fullName));

        return new Student
        {
            FullName = fullName,
            Id = Guid.NewGuid()
        };
    }

    public void AddGradeToStudent(Guid moduleId, int grade)
    {
        if (moduleId == Guid.Empty)
            throw new ArgumentException("Invalid moduleId");

        if (grade < 0 || grade > 100)
            throw new ArgumentException("Score must be 0-100");

        var existing = _grades.Any(g => g.ModuleId == moduleId);
        if (existing)
            throw new InvalidOperationException("Grade already exists. Use ApplyResit.");

        _grades.Add(new Grade(moduleId, grade));
    }

    public void AddResitGradeToStudent(Guid moduleId, int resitGrade)
    {
        if (moduleId == Guid.Empty)
            throw new ArgumentException("Invalid moduleId");

        if (resitGrade < 0 || resitGrade > 100)
            throw new ArgumentException("Resit score must be 0-100");

        var grade = _grades.FirstOrDefault(g => g.ModuleId == moduleId);
        if (grade == null)
            throw new InvalidOperationException("No existing grade found for resit.");

        grade.AddResitGrade(resitGrade);
    }

    public void AddClassToStudent(Guid seminarGroupId)
    {
        if (seminarGroupId == Guid.Empty)
            throw new ArgumentException("Invalid seminarGroupId");

        if (_studentClass.Any(sc => sc.SeminarGroupId == seminarGroupId))
            throw new InvalidOperationException("Student already register in this class");

        _studentClass.Add(new StudentClass(Id, seminarGroupId));
    }

    public void AddConflictToStudent(Guid seminarGroupId, ConflictType conflictType)
    {
        if (seminarGroupId == Guid.Empty)
            throw new ArgumentException("Invalid seminarGroupId");

        if (_studentConflict.Any(sc => sc.SeminarGroupId == seminarGroupId))
            throw new InvalidOperationException("Student already have Conflict in this class");

        _studentConflict.Add(new StudentConflict(Id, seminarGroupId, conflictType));
    }


    public void AddModulesToStudent(List<Guid> moduleIds)
    {
        foreach (var moduleId in moduleIds)
        {
            if (moduleId == Guid.Empty)
                throw new ArgumentException("Invalid seminarGroupId");

            _studentModule.Add(new StudentModule(Id, moduleId));
        }
    }
}