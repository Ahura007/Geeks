using University.Infra;
using University.Infra.Application;

namespace University.Application.Students.Command.AddModuleToStudent;

public sealed class AddModuleToStudentCommandHandler
{
    public ApplicationServiceResult Handle(AddModuleToStudentCommand command)
    {
        var student = DbContext.Students.FirstOrDefault(c => c.Id == command.StudentId);
        if (student is null)
            return new ApplicationServiceResult
            {
                State = ApplicationServiceState.NotFound,
                Message = "دانش آموز یافت نشد"
            };
        student.AddModulesToStudent(command.ModuleIds);
        return new ApplicationServiceResult { State = ApplicationServiceState.Ok };
    }
}