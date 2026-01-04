using System;
using System.Linq;
using University.Domain.SeminarGroups.Aggregate;
using University.Infra;
using University.Infra.Application;
using University.Infra.Core.Enum;

namespace University.Application.SeminarGroups.Command.Create;

public sealed class CreateSeminarGroupCommandHandler
{
    public ApplicationServiceResult Handle(CreateSeminarGroupCommand command)
    {
        if (command.ModuleId == Guid.Empty)
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.InvalidDomainState,
                Message = "شناسه ماژول معتبر نیست."
            };

        if (command.Capacity <= 0)
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.InvalidDomainState,
                Message = "ظرفیت گروه باید بزرگ‌تر از صفر باشد."
            };

        if (command.StartTime >= command.EndTime)
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.InvalidDomainState,
                Message = "زمان پایان باید بعد از زمان شروع باشد."
            };

        if (string.IsNullOrWhiteSpace(command.LocationOrLink))
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.InvalidDomainState,
                Message = "محل یا لینک کلاس نمی‌تواند خالی باشد."
            };

        if (command.SeminarGroupType == SeminarGroupType.Virtual)
        {
            if (!Uri.TryCreate(command.LocationOrLink.Trim(), UriKind.Absolute, out var uriResult) ||
                (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                return new ApplicationServiceResult
                {
                    State = ApplicationServiceState.InvalidDomainState,
                    Message = "برای کلاس مجازی، لینک معتبر با پروتکل http یا https وارد کنید."
                };
            }
        }

        var module = DbContext.Modules.FirstOrDefault(m => m.Id == command.ModuleId);
        if (module == null)
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.NotFound,
                Message = "ماژول مورد نظر یافت نشد."
            };

        var currentTotalSeminarCapacity = DbContext.SeminarGroups
            .Where(sg => sg.ModuleId == command.ModuleId)
            .Sum(sg => sg.Capacity);

        var projectedTotalCapacity = currentTotalSeminarCapacity + command.Capacity;

        if (projectedTotalCapacity > module.Capacity)
        {
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.InvalidDomainState,
                Message = $"نمی‌توان گروه سمینار جدید ایجاد کرد.\n" +
                          $"درس: {module.Name} (کد: {module.Code})\n" +
                          $"ظرفیت کل درس: {module.Capacity} نفر\n" +
                          $"مجموع ظرفیت گروه‌های فعلی: {currentTotalSeminarCapacity} نفر\n" +
                          $"ظرفیت گروه جدید: {command.Capacity} نفر\n" +
                          $"مجموع پس از افزودن: {projectedTotalCapacity} نفر\n" +
                          $"این مقدار از ظرفیت مجاز درس بیشتر است."
            };
        }

        // گروه‌های موجود در همان روز هفته
        var existingGroupsInSameDay = DbContext.SeminarGroups
            .Where(sg => sg.DayOfWeek == command.DayOfWeek)
            .ToList();

        foreach (var existing in existingGroupsInSameDay)
        {
            // تداخل زمانی عمومی (روز و ساعت)
            bool timeOverlap = command.StartTime < existing.EndTime && command.EndTime > existing.StartTime;

            if (timeOverlap)
            {
                // اگر هر دو حضوری باشند و محل (شماره کلاس) یکسان باشد
                if (command.SeminarGroupType == SeminarGroupType.FaceToFace &&
                    existing.SeminarGroupType == SeminarGroupType.FaceToFace &&
                    string.Equals(command.LocationOrLink.Trim(), existing.LocationOrLink.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    var startStr = command.StartTime.ToString(@"hh\:mm");
                    var endStr = command.EndTime.ToString(@"hh\:mm");

                    return new ApplicationServiceResult
                    {
                        State = ApplicationServiceState.InvalidDomainState,
                        Message = $"تداخل زمانی و مکانی در روز {command.DayOfWeek} ساعت ({startStr} تا {endStr}) با گروه دیگر در کلاس {command.LocationOrLink} وجود دارد."
                    };
                }

                // تداخل زمانی عمومی (حتی اگر مجازی یا حضوری متفاوت باشد)
                var startStrGeneral = command.StartTime.ToString(@"hh\:mm");
                var endStrGeneral = command.EndTime.ToString(@"hh\:mm");

                return new ApplicationServiceResult
                {
                    State = ApplicationServiceState.InvalidDomainState,
                    Message = $"تداخل زمانی در روز {command.DayOfWeek} ساعت ({startStrGeneral} تا {endStrGeneral}) با گروه سمینار دیگر وجود دارد."
                };
            }
        }

        // چک تکراری بودن کامل گروه
        var isDuplicate = DbContext.SeminarGroups.Any(sg =>
            sg.ModuleId == command.ModuleId &&
            sg.DayOfWeek == command.DayOfWeek &&
            sg.StartTime == command.StartTime &&
            sg.EndTime == command.EndTime &&
            sg.Capacity == command.Capacity &&
            sg.SeminarGroupType == command.SeminarGroupType &&
            string.Equals(sg.LocationOrLink.Trim(), command.LocationOrLink.Trim(), StringComparison.OrdinalIgnoreCase));

        if (isDuplicate)
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.InvalidDomainState,
                Message = "این گروه سمینار قبلاً ثبت شده است (کاملاً تکراری)."
            };

        var seminarGroup = SeminarGroup.Create(
            command.ModuleId,
            command.DayOfWeek,
            command.StartTime,
            command.EndTime,
            command.Capacity,
            command.SeminarGroupType,
            command.LocationOrLink.Trim()
        );

        DbContext.SeminarGroups.Add(seminarGroup);

        return new ApplicationServiceResult
        {
            State = ApplicationServiceState.Ok,
            Message = "گروه سمینار با موفقیت ثبت شد."
        };
    }
}