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
    // سرویس دامنه برای بررسی قوانین ثبت‌نام
    private readonly SeminarGroupRegistrationDomainService _domainService;

    public RegisterStudentInClassesAppService()
    {
        // نمونه‌سازی سرویس دامنه
        _domainService = new SeminarGroupRegistrationDomainService();
    }

    public void Register(Guid studentId, IReadOnlyCollection<Guid> seminarGroupIds)
    {
        // جستجوی دانشجو در لیست دانشجویان
        var student = DbContext.Students.FirstOrDefault(x => x.Id == studentId);

        // اگر دانشجو پیدا نشد خطا بده
        if (student == null)
            throw new Exception("دانشجو یافت نشد");

        // اگر هیچ کلاسی انتخاب نشده باشد عملیات را متوقف کن
        if (!seminarGroupIds.Any())
            return;

        // دریافت گروه‌های سمینار انتخاب‌شده توسط دانشجو
        var seminarGroups = DbContext.SeminarGroups
            .Where(sg => seminarGroupIds.Contains(sg.Id))
            .ToList();

        // اگر برخی از کلاس‌ها وجود نداشته باشند خطا بده
        if (seminarGroups.Count != seminarGroupIds.Count)
            throw new Exception("برخی از کلاس‌های انتخابی یافت نشدند");

        // دریافت شناسه ماژول‌هایی که دانشجو قبلاً برداشته
        var studentModuleIds = student.StudentModule.Select(sm => sm.ModuleId).ToHashSet();

        // دریافت ظرفیت کل هر ماژول که دانشجو دارد
        var moduleCapacities = DbContext.Modules
            .Where(m => studentModuleIds.Contains(m.Id))
            .ToDictionary(m => m.Id, m => m.Capacity);

        // محاسبه تعداد دانشجوهای فعلی ثبت‌نام‌شده در هر ماژول
        var currentStudentsInModules = DbContext.Students
            .SelectMany(s => s.StudentModule)
            .Where(sm => studentModuleIds.Contains(sm.ModuleId))
            .GroupBy(sm => sm.ModuleId)
            .ToDictionary(g => g.Key, g => g.Count());

        // دریافت گروه‌های سمینار که دانشجو قبلاً ثبت‌نام کرده
        var registeredSeminarGroups = student.StudentSeminarGroup
            .Select(ssg => DbContext.SeminarGroups.FirstOrDefault(sg => sg.Id == ssg.SeminarGroupId))
            .Where(sg => sg != null)
            .ToList();

        // ترتیب تصادفی گروه‌ها برای عدالت در زمان ظرفیت محدود
        var orderedSeminarGroups = seminarGroups.OrderBy(_ => Guid.NewGuid()).ToList();

        // لیست گروه‌هایی که اعتبارسنجی موفق داشته‌اند
        var successfullyValidatedSeminars = new List<SeminarGroup>();

        // مرحله اعتبارسنجی برای هر گروه
        foreach (var seminarGroup in orderedSeminarGroups)
        {
            // بررسی اینکه دانشجو درس مرتبط با این گروه را برداشته باشد
            if (!studentModuleIds.Contains(seminarGroup.ModuleId))
                throw new DomainConflictException(ConflictType.InvalidModule, "دانشجو این درس را برداشته نیست");

            // تعداد کل ثبت‌نام در این گروه سمینار (از همه دانشجویان)
            var groupTotalRegisterCount = DbContext.Students
                .SelectMany(s => s.StudentSeminarGroup)
                .Count(ssg => ssg.SeminarGroupId == seminarGroup.Id);

            // چک ظرفیت گروه سمینار
            if (groupTotalRegisterCount >= seminarGroup.Capacity)
            {
                student.AddConflictToStudent(seminarGroup.Id, ConflictType.CapacityFull);
                throw new DomainConflictException(ConflictType.CapacityFull, "ظرفیت این گروه سمینار تکمیل شده است");
            }

            // لیست به‌روز شده از گروه‌های ثبت‌شده شامل قبلی و جدیدهای موفق
            var tempRegistered = registeredSeminarGroups
                .Concat(successfullyValidatedSeminars)
                .ToList();

            try
            {
                // اعتبارسنجی قوانین ثبت‌نام توسط سرویس دامنه
                var isValid = _domainService.ValidateRegistration(
                    student: student,
                    targetSeminarGroup: seminarGroup,
                    registeredSeminarGroups: tempRegistered,
                    currentRegisterCount: groupTotalRegisterCount,
                    moduleCapacity: moduleCapacities[seminarGroup.ModuleId],
                    out var conflictType);

                // اگر ثبت‌نام تکراری باشد فقط رد شود و خطا ندهد
                if (!isValid && conflictType == ConflictType.DuplicateRegistration)
                    continue;
            }
            catch (DomainConflictException ex)
            {
                // ثبت نوع تداخل در تاریخچه دانشجو
                student.AddConflictToStudent(seminarGroup.Id, ex.ConflictType);
                // پرتاب دوباره خطا برای توقف عملیات
                throw;
            }

            //// محاسبه تعداد دانشجو در ماژول پس از ثبت این گروه
            //var projectedCountInModule = currentStudentsInModules.GetValueOrDefault(seminarGroup.ModuleId)
            //    + successfullyValidatedSeminars.Count(s => s.ModuleId == seminarGroup.ModuleId)
            //    + 1;

            //// بررسی ظرفیت کل ماژول
            //if (projectedCountInModule > moduleCapacities[seminarGroup.ModuleId])
            //{
            //    student.AddConflictToStudent(seminarGroup.Id, ConflictType.ModuleCapacityExceeded);
            //    throw new DomainConflictException(ConflictType.ModuleCapacityExceeded, "ظرفیت کل درس تکمیل شده است");
            //}

            // اضافه کردن گروه به لیست موفق‌ها
            successfullyValidatedSeminars.Add(seminarGroup);
        }

        // ثبت نهایی گروه‌های موفق
        foreach (var seminarGroup in successfullyValidatedSeminars)
        {
            student.AddSeminarGroupToStudent(seminarGroup.Id);
        }
    }
}