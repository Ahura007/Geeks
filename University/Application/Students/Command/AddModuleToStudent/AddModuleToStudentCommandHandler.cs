using University.Infra;
using University.Infra.Application;

namespace University.Application.Students.Command.AddModuleToStudent;

public sealed class AddModuleToStudentCommandHandler
{
    public ApplicationServiceResult Handle(AddModuleToStudentCommand command)
    {
        if ( command.StudentId == Guid.Empty || !command.ModuleIds.Any())
        {
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.InvalidDomainState,
                Message = "درخواست نامعتبر است. شناسه دانشجو یا لیست درس‌ها نمی‌تواند خالی باشد."
            };
        }

     
        var student = DbContext.Students.FirstOrDefault(s => s.Id == command.StudentId);
        if (student == null)
        {
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.NotFound,
                Message = "دانشجو یافت نشد."
            };
        }

        var requestedModules = DbContext.Modules
            .Where(m => command.ModuleIds.Contains(m.Id))
            .ToList();

     
        if (requestedModules.Count != command.ModuleIds.Count)
        {
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.NotFound,
                Message = "برخی از درس‌های انتخابی یافت نشدند یا معتبر نیستند."
            };
        }

     
        var currentEnrollmentCounts = DbContext.Students
            .SelectMany(s => s.StudentModule)
            .Where(sm => command.ModuleIds.Contains(sm.ModuleId))
            .GroupBy(sm => sm.ModuleId)
            .ToDictionary(g => g.Key, g => g.Count());

    
        foreach (var module in requestedModules)
        {
            var currentCount = currentEnrollmentCounts.GetValueOrDefault(module.Id, 0);
            var projectedCount = currentCount + 1;  

            if (projectedCount > module.Capacity)
            {
                return new ApplicationServiceResult
                {
                    State = ApplicationServiceState.InvalidDomainState,
                    Message = $"ظرفیت درس «{module.Name}» (کد: {module.Code}) تکمیل شده است. " +
                              $"حداکثر ظرفیت: {module.Capacity} نفر، فعلی: {currentCount} نفر."
                };
            }
        }

        student.AddModulesToStudent(command.ModuleIds);

        return new ApplicationServiceResult
        {
            State = ApplicationServiceState.Ok,
            Message = "درس(ها) با موفقیت به دانشجو اختصاص یافت."
        };
    }
}