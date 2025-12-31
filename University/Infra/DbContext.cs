using University.Core.Enum;
using University.Domain.Classes.Aggregate;
using University.Domain.Lessons.Aggregate;
using University.Domain.Students.Aggregate;

namespace University.Infra;

/// <summary>
///     InMemoryDbContext
/// </summary>
internal class DbContext
{
    public static List<Student> Students { get; set; } = [];
    public static List<Lesson> Lessons { get; set; } = [];
    public static List<Class> Classes { get; set; } = [];

    public static void SeedData()
    {
        var s1 = Student.Create("علی رضایی");
        var s2 = Student.Create("یوسف مرادی");
        Students.Add(Student.Create("هادی زمانی"));
        Students.Add(Student.Create("غلام صنعتی"));

        Students.Add(s1);
        Students.Add(s2);

        Lessons.Add(Lesson.Create("ریاضی مهندسی"));
        Lessons.Add(Lesson.Create("علوم"));
        Lessons.Add(Lesson.Create("ستاره شناسی پیشرفته"));

        var tomorrow = DateTimeOffset.UtcNow.Date.AddDays(1);


        var c1 = Class.Create(
            Lessons[0]!.Id, //کلاس مربوط به درس اول
            tomorrow.AddHours(8), // فردا از ساعت 8 صبح
            tomorrow.AddHours(10), // تا ساعت 10 صبح
            2, // ظرفیت کلاس 2 نفر
            ClassType.FaceToFace, // حضورس
            "301");

        var c2 = Class.Create(Lessons[1]!.Id, tomorrow.AddHours(12), tomorrow.AddHours(14), 120, ClassType.Virtual,
            "https://vc.BBB.ir/b/mah-upw-4fk");

        var c3 = Class.Create(Lessons[2]!.Id, tomorrow.AddDays(1).AddHours(12), tomorrow.AddDays(1).AddHours(14), 1,
            ClassType.FaceToFace,
            "301");

        Classes.Add(c1); // کلاس 301
        Classes.Add(c2);
        Classes.Add(c3);


        s1.AddClassToStudent(c1.Id); // انتساب کلاس اول به دانش اموز علی رضایی
        s1.AddClassToStudent(c2.Id); // انتساب کلاس دوم به دانش اموز علی رضایی


        s2.AddClassToStudent(c2.Id); // انتساب کلاس دوم به دانش اموز یوسف مرادی
    }
}