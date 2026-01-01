using University.Domain.Students.Aggregate;
using University.Infra;
using University.Infra.Application;

namespace University.Application.Students.Command.Create;

public sealed class CreateStudentCommandHandler
{
    public ApplicationServiceResult Handle(CreateStudentCommand command)
    {
        var student = Student.Create(command.FullName);
        DbContext.Students.Add(student);
        return new ApplicationServiceResult { State = ApplicationServiceState.Ok };
    }
}