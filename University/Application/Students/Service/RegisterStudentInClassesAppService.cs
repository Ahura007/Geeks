using University.Domain.Students.Service;
using University.Infra;
using University.Infra.Core.Exceptions;

namespace University.Application.Students.Service;

public sealed class RegisterStudentInClassesAppService
{
    private readonly ClassRegistrationDomainService _domainService;

    public RegisterStudentInClassesAppService()
    {
        _domainService = new ClassRegistrationDomainService();
    }

    public void Register(Guid studentId, IReadOnlyCollection<Guid> seminarGroupIds)
    {
        var student = DbContext.Students.FirstOrDefault(x => x.Id == studentId);
        if (student is null)
            throw new Exception("دانشجو یافت نشد");

        var classes = DbContext.SeminarGroups.Where(c => seminarGroupIds.Contains(c.Id)).ToList();
        if (classes.Count != seminarGroupIds.Count)
            throw new Exception("برخی کلاس‌ها یافت نشدند");

        var registeredClasses = student.StudentClass
            .Select(sc => DbContext.SeminarGroups.FirstOrDefault(c => c.Id == sc.SeminarGroupId))
            .Where(c => c is not null)
            .ToList();

        var orderedClasses = classes
            .Select(c => new { Class = c, RequestTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds() })
            .OrderBy(c => c.RequestTime)
            .Select(c => c.Class)
            .ToList();

        foreach (var cls in orderedClasses)
        {
            var registerCount = DbContext.Students.SelectMany(s => s.StudentClass)
                .Count(sc => sc.SeminarGroupId == cls.Id);

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

        foreach (var cls in orderedClasses) student.AddClassToStudent(cls.Id);
    }
}