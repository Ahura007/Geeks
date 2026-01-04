using University.Domain.SeminarGroups.Aggregate;
using University.Domain.Students.Aggregate;
using University.Infra.Core.Enum;
using University.Infra.Core.Exceptions;

namespace University.Domain.Students.Service;

internal sealed class SeminarGroupRegistrationDomainService
{
    public bool ValidateRegistration(
        Student student,
        SeminarGroup targetSeminarGroup,
        IReadOnlyCollection<SeminarGroup> registeredSeminarGroups,
        int currentRegisterCount,
        int moduleCapacity,
        out ConflictType? conflictType)
    {
        conflictType = null;

        // تکراری بودن
        if (currentRegisterCount > 0)
        {
            conflictType = ConflictType.DuplicateRegistration;
            return false;
        }

        // ظرفیت گروه
        if (currentRegisterCount >= targetSeminarGroup.Capacity)
            throw new DomainConflictException(ConflictType.CapacityFull, "ظرفیت این گروه سمینار تکمیل شده است.");

        // تداخل زمانی
        var overlap = registeredSeminarGroups.FirstOrDefault(existing => existing.OverlapsWith(targetSeminarGroup));
        if (overlap != null)
            throw new DomainConflictException(ConflictType.TimeOverlap, $"تداخل زمانی با کلاس دیگر ({overlap.StartTime:HH:mm}-{overlap.EndTime:HH:mm})");

        return true;
    }
}
