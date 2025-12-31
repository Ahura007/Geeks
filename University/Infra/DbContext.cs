using University.Core.Enum;
using University.Domain.Classes.Aggregate;
using University.Domain.Lessons.Aggregate;
using University.Domain.Students.Aggregate;

namespace University.Infra;


/// <summary>
/// InMemoryDbContext
/// </summary>
internal class DbContext
{
    public static List<Student> Students { get; set; } = [];
    public static List<Lesson> Lessons { get; set; } = [];
    public static List<Class> Classes { get; set; } = [];

    public static void SeedData()
    {
        Students.Add(Student.Create("علی رضایی"));
        Students.Add(Student.Create("یوسف مرادی"));

        Lessons.Add(Lesson.Create("ریاضی مهندسی"));
        Lessons.Add(Lesson.Create("علوم"));

        var tomorrow = DateTimeOffset.UtcNow.Date.AddDays(1);

        Classes.Add(Class.Create(
            Lessons[0]!.Id,//کلاس مربوط به درس اول
            tomorrow.AddHours(8), // فردا از ساعت 8 صبح
            tomorrow.AddHours(10),// تا ساعت 10 صبح
            2, // ظرفیت کلاس 2 نفر
            ClassType.FaceToFace,// حضورس
            "301"));// کلاس 301

        Classes.Add(Class.Create(Lessons[1]!.Id, tomorrow.AddHours(12), tomorrow.AddHours(14), 120, ClassType.Virtual, "https://vc.BBB.ir/b/mah-upw-4fk"));
    }
}