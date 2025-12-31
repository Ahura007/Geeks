using University.Core.Enum;
using University.Core.Exceptions;
using University.Domain.SeminarGroups.Aggregate;
using University.Domain.Students.Aggregate;

namespace University.Domain.Students.Service;

internal sealed class ClassRegistrationDomainService
{
    public void ValidateRegistration(Student student, SeminarGroup targetSeminarGroup,
        IReadOnlyCollection<SeminarGroup> registeredClasses,
        int currentRegisterCount)
    {
        // تکراری
        if (student.StudentClass.Any(sc => sc.ClassId == targetSeminarGroup.Id))
            throw new DomainConflictException(ConflictType.DuplicateRegistration,
                "دانشجو قبلاً در این کلاس ثبت‌نام کرده است.");

        // ظرفیت
        if (currentRegisterCount >= targetSeminarGroup.Capacity)
            throw new DomainConflictException(ConflictType.CapacityFull, "ظرفیت کلاس تکمیل شده است.");

        // تداخل زمانی
        var conflict = registeredClasses.FirstOrDefault(existing =>
            existing.StartTimeUtc < targetSeminarGroup.EndTimeUtc &&
            targetSeminarGroup.StartTimeUtc < existing.EndTimeUtc);
        if (conflict != null)
            throw new DomainConflictException(ConflictType.TimeOverlap,
                $"تداخل زمانی با کلاس {conflict.Id} " + $"({conflict.StartTimeUtc:HH:mm}-{conflict.EndTimeUtc:HH:mm})");
    }
}