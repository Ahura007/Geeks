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

        // گرفتن ماژول برای چک ظرفیت کل
        var module = DbContext.Modules.FirstOrDefault(m => m.Id == command.ModuleId);
        if (module == null)
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.NotFound,
                Message = "ماژول مورد نظر یافت نشد."
            };

        // مجموع ظرفیت فعلی گروه‌های سمینار این ماژول
        var currentTotalSeminarCapacity = DbContext.SeminarGroups
            .Where(sg => sg.ModuleId == command.ModuleId)
            .Sum(sg => sg.Capacity);

        // مجموع ظرفیت بعد از اضافه کردن این گروه جدید
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

        // چک تداخل زمانی
        var existingGroups = DbContext.SeminarGroups
            .Where(sg => sg.ModuleId == command.ModuleId && sg.DayOfWeek == command.DayOfWeek)
            .ToList();

        var hasTimeConflict = existingGroups.Any(sg =>
            command.StartTime < sg.EndTime && command.EndTime > sg.StartTime);

        if (hasTimeConflict)
        {
            var startStr = command.StartTime.ToString(@"hh\:mm");
            var endStr = command.EndTime.ToString(@"hh\:mm");

            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.InvalidDomainState,
                Message = $"این بازه زمانی ({startStr} تا {endStr}) در روز {command.DayOfWeek} با گروه سمینار دیگری تداخل دارد."
            };
        }

        // چک تکراری بودن
        var isDuplicate = existingGroups.Any(sg =>
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

        // ایجاد و اضافه کردن گروه سمینار
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