using University.Core.Exceptions;
using University.Domain.Students.Service;
using University.Infra;

namespace University.Application.Students;

internal sealed class RegisterStudentInClassesAppService
{
    private readonly ClassRegistrationDomainService _domainService;

    public RegisterStudentInClassesAppService()
    {
        _domainService = new ClassRegistrationDomainService();
    }

    public void Register(Guid studentId, IReadOnlyCollection<Guid> classIds)
    {
        var student = DbContext.Students.FirstOrDefault(x => x.Id == studentId);
        if (student is null)
            throw new Exception("دانشجو یافت نشد");

        var classes = DbContext.Classes.Where(c => classIds.Contains(c.Id)).ToList();
        if (classes.Count != classIds.Count)
            throw new Exception("برخی کلاس‌ها یافت نشدند");

        var registeredClasses = student.StudentClass
            .Select(sc => DbContext.Classes.FirstOrDefault(c => c.Id == sc.ClassId))
            .Where(c => c is not null)
            .ToList();

        var orderedClasses = classes
            .Select(c => new { Class = c, RequestTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds() })
            .OrderBy(c => c.RequestTime)
            .Select(c => c.Class)
            .ToList();

        foreach (var cls in orderedClasses)
        {
            var registerCount = DbContext.Students.SelectMany(s => s.StudentClass).Count(sc => sc.ClassId == cls.Id);

            try
            {
                _domainService.ValidateRegistration(student, cls, registeredClasses, registerCount);
            }
            catch (DomainConflictException ex)
            {
                student.AddConflictToStudent(cls.Id, ex.ConflictType);
                throw;
            }
        }

        foreach (var cls in orderedClasses)
        {
            student.AddClassToStudent(cls.Id);
        }
    }
}
