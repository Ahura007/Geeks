using System;
using System.Collections.Generic;
using System.Linq;
using University.Domain.SeminarGroups.Aggregate;
using University.Domain.Students.Service;
using University.Infra;
using University.Infra.Core.Enum;
using University.Infra.Core.Exceptions;

namespace University.Application.Students.Service;

public sealed class RegisterStudentInClassesAppService
{
    private readonly SeminarGroupRegistrationDomainService _domainService;

    public RegisterStudentInClassesAppService()
    {
        _domainService = new SeminarGroupRegistrationDomainService();
    }

    public void Register(Guid studentId, IReadOnlyCollection<Guid> seminarGroupIds)
    {
        var student = DbContext.Students.FirstOrDefault(x => x.Id == studentId);

        if (student == null)
            throw new Exception("دانشجو یافت نشد");

        if (!seminarGroupIds.Any())
            return;

        var seminarGroups = DbContext.SeminarGroups
            .Where(sg => seminarGroupIds.Contains(sg.Id))
            .ToList();

        if (seminarGroups.Count != seminarGroupIds.Count)
            throw new Exception("برخی از کلاس‌های انتخابی یافت نشدند");

        var studentModuleIds = student.StudentModule.Select(sm => sm.ModuleId).ToHashSet();

        var moduleCapacities = DbContext.Modules
            .Where(m => studentModuleIds.Contains(m.Id))
            .ToDictionary(m => m.Id, m => m.Capacity);

        var currentStudentsInModules = DbContext.Students
            .SelectMany(s => s.StudentModule)
            .Where(sm => studentModuleIds.Contains(sm.ModuleId))
            .GroupBy(sm => sm.ModuleId)
            .ToDictionary(g => g.Key, g => g.Count());

        var registeredSeminarGroups = student.StudentSeminarGroup
            .Select(ssg => DbContext.SeminarGroups.FirstOrDefault(sg => sg.Id == ssg.SeminarGroupId))
            .Where(sg => sg != null)
            .ToList();

        var orderedSeminarGroups = seminarGroups.OrderBy(_ => Guid.NewGuid()).ToList();

        var successfullyValidatedSeminars = new List<SeminarGroup>();

        foreach (var seminarGroup in orderedSeminarGroups)
        {
            if (!studentModuleIds.Contains(seminarGroup.ModuleId))
                throw new DomainConflictException(ConflictType.InvalidModule, "دانشجو این درس را برداشته نیست");

            var currentRegisterCount = DbContext.Students
                .SelectMany(s => s.StudentSeminarGroup)
                .Count(ssg => ssg.SeminarGroupId == seminarGroup.Id);

            if (currentRegisterCount >= seminarGroup.Capacity)
            {
                student.AddConflictToStudent(seminarGroup.Id, ConflictType.CapacityFull);
                throw new DomainConflictException(ConflictType.CapacityFull, "ظرفیت این گروه سمینار تکمیل شده است");
            }

            var tempRegistered = registeredSeminarGroups
                .Concat(successfullyValidatedSeminars)
                .ToList();

            try
            {
                var isValid = _domainService.ValidateRegistration(
                    student: student,
                    targetSeminarGroup: seminarGroup,
                    registeredSeminarGroups: tempRegistered,
                    currentRegisterCount: currentRegisterCount,
                    moduleCapacity: moduleCapacities[seminarGroup.ModuleId],
                    out var conflictType);

                if (!isValid && conflictType == ConflictType.DuplicateRegistration)
                    continue;
            }
            catch (DomainConflictException ex)
            {
                student.AddConflictToStudent(seminarGroup.Id, ex.ConflictType);
                throw;
            }

            var projectedCountInModule = currentStudentsInModules.GetValueOrDefault(seminarGroup.ModuleId)
                + successfullyValidatedSeminars.Count(s => s.ModuleId == seminarGroup.ModuleId)
                + 1;

            if (projectedCountInModule > moduleCapacities[seminarGroup.ModuleId])
            {
                student.AddConflictToStudent(seminarGroup.Id, ConflictType.ModuleCapacityExceeded);
                throw new DomainConflictException(ConflictType.ModuleCapacityExceeded, "ظرفیت کل درس تکمیل شده است");
            }

            successfullyValidatedSeminars.Add(seminarGroup);
        }

        foreach (var seminarGroup in successfullyValidatedSeminars)
        {
            student.AddSeminarGroupToStudent(seminarGroup.Id);
        }
    }
}