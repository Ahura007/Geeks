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
                Message = "شناسه ماژول معتبر نیست.."
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
            if (!Uri.TryCreate(command.LocationOrLink.Trim(), UriKind.Absolute, out var uriResult) ||
                (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
                return new ApplicationServiceResult
                {
                    State = ApplicationServiceState.InvalidDomainState,
                    Message = "برای کلاس مجازی، لینک معتبر با پروتکل http یا https وارد کنید."
                };


        var existingGroups = DbContext.SeminarGroups
            .Where(sg => sg.ModuleId == command.ModuleId && sg.DayOfWeek == command.DayOfWeek)
            .ToList();


        var hasTimeConflict = existingGroups.Any(sg =>
            command.StartTime < sg.EndTime && command.EndTime > sg.StartTime);

        if (hasTimeConflict)
        {
            string startStr = command.StartTime.ToString(@"hh\:mm");
            string endStr = command.EndTime.ToString(@"hh\:mm");

            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.InvalidDomainState,
                Message = $"این بازه زمانی ({startStr} تا {endStr}) در روز {command.DayOfWeek} با گروه سمینار دیگری تداخل دارد."
            };
        }


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
                Message = "این گروه سمینار قبلا\u064b ثبت شده است (کاملا\u064b تکراری)."
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