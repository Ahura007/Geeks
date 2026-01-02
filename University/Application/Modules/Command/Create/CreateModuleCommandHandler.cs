using University.Domain.Modules.Aggregate;
using University.Infra;
using University.Infra.Application;

namespace University.Application.Modules.Command.Create;

public sealed class CreateModuleCommandHandler
{
    public ApplicationServiceResult Handle(CreateModuleCommand command)
    {
        if (DbContext.Employees.All(x => x.Id != command.ResponsibleStaffId))
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.NotFound,
                Message = "کاربری با این مشخصات یافت نشد"
            };

        var module = Module.Create(command.Code, command.Name, command.Capacity, command.ResponsibleStaffId);
        DbContext.Modules.Add(module);
        return new ApplicationServiceResult { State = ApplicationServiceState.Ok };
    }
}