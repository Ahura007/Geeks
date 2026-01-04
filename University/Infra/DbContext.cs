using University.Application.Students.Query.CommonResult;
using University.Domain.Employees.Aggregate;
using University.Domain.Modules.Aggregate;
using University.Domain.SeminarGroups.Aggregate;
using University.Domain.Students.Aggregate;
using University.Infra.Core.Enum;

namespace University.Infra;

public class DbContext
{
    internal static List<Student> Students { get; set; } = [];
    internal static List<Module> Modules { get; set; } = [];
    internal static List<SeminarGroup> SeminarGroups { get; set; } = [];
    internal static List<Employee> Employees { get; set; } = [];

    public static void SeedData()
    {
        var employee1 = Employee.Create("کارمند یک");
        var employee2 = Employee.Create("کارمند دو");
        var employee3 = Employee.Create("کارمند سه");
        Employees.AddRange([employee1, employee2, employee3]);

        var student1 = Student.Create("علی رضایی");
        var student2 = Student.Create("یوسف مرادی");
        var student3 = Student.Create("کریم خدا یاری");
        var student4 = Student.Create("احسان دینی");
        var student5 = Student.Create("اشکان قدیمی");
        Students.AddRange([student1, student2, student3, student4, student5]);

        var module1 = Module.Create("A - 10", "ریاضی ", 4, employee1.Id);
        var module2 = Module.Create("B - 11", "علوم", 4, employee1.Id);
        var module3 = Module.Create("C - 12", "دینی", 3, employee2.Id);
        Modules.AddRange([module1, module2, module3]);

        //var seminarGroup1 = SeminarGroup.Create(module1.Id, DayOfWeek.Saturday, TimeSpan.FromHours(7), TimeSpan.FromHours(8), 2, SeminarGroupType.FaceToFace, "301");
        //var seminarGroup2 = SeminarGroup.Create(module1.Id, DayOfWeek.Saturday, TimeSpan.FromHours(9), TimeSpan.FromHours(10), 1, SeminarGroupType.Virtual, "http://aaa.ir/a1");
        //var seminarGroup3 = SeminarGroup.Create(module2.Id, DayOfWeek.Tuesday, TimeSpan.FromHours(9), TimeSpan.FromHours(10), 3, SeminarGroupType.Virtual, "http://bbb.ir/b1");
        //var seminarGroup4 = SeminarGroup.Create(module3.Id, DayOfWeek.Friday, TimeSpan.FromHours(9), TimeSpan.FromHours(12), 1, SeminarGroupType.FaceToFace, "301");
        //SeminarGroups.AddRange([seminarGroup1, seminarGroup2, seminarGroup3, seminarGroup4]);



        //student1.AddModulesToStudent([module1.Id]);
        //student2.AddModulesToStudent([module1.Id]);

        //student1.AddSeminarGroupToStudent(seminarGroup1.Id);
        //student2.AddSeminarGroupToStudent(seminarGroup2.Id);
    }
}