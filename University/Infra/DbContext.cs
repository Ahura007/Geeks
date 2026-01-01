using University.Domain.Modules.Aggregate;
using University.Domain.SeminarGroups.Aggregate;
using University.Domain.Students.Aggregate;
using University.Infra.Core.Enum;

namespace University.Infra;

/// <summary>
///     InMemoryDbContext
/// </summary>
internal class DbContext
{
    public static List<Student> Students { get; set; } = [];
    public static List<Module> Modules { get; set; } = [];
    public static List<SeminarGroup> SeminarGroups { get; set; } = [];

    public static void SeedData()
    {
        var s1 = Student.Create("علی رضایی");
        var s2 = Student.Create("یوسف مرادی");
        Students.Add(Student.Create("هادی زمانی"));
        Students.Add(Student.Create("غلام صنعتی"));

        Students.Add(s1);
        Students.Add(s2);

        Modules.Add(Module.Create("ریاضی مهندسی"));
        Modules.Add(Module.Create("علوم"));
        Modules.Add(Module.Create("ستاره شناسی پیشرفته"));


        var c1 = SeminarGroup.Create(
            Modules[0]!.Id, //کلاس مربوط به درس اول
            DayOfWeek.Saturday,
            TimeSpan.FromHours(6), // فردا از ساعت 8 صبح
            TimeSpan.FromHours(8), // تا ساعت 10 صبح
            2, // ظرفیت کلاس 2 نفر
            SeminarGroupType.FaceToFace, // حضورس
            "301");

        var c2 = SeminarGroup.Create(Modules[1]!.Id, DayOfWeek.Saturday, TimeSpan.FromHours(8), TimeSpan.FromHours(10),
            120,
            SeminarGroupType.Virtual,
            "https://vc.BBB.ir/b/mah-upw-4fk");

        var c3 = SeminarGroup.Create(Modules[2]!.Id, DayOfWeek.Thursday, TimeSpan.FromHours(10), TimeSpan.FromHours(12),
            1,
            SeminarGroupType.FaceToFace,
            "301");

        SeminarGroups.Add(c1); // کلاس 301
        SeminarGroups.Add(c2);
        SeminarGroups.Add(c3);


        s1.AddClassToStudent(c1.Id); // انتساب کلاس اول به دانش اموز علی رضایی
        s1.AddClassToStudent(c2.Id); // انتساب کلاس دوم به دانش اموز علی رضایی


        s2.AddClassToStudent(c2.Id); // انتساب کلاس دوم به دانش اموز یوسف مرادی
    }
}