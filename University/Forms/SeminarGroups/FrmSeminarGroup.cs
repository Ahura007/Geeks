using University.Core.Enum;
using University.Core.Extension;
using University.Domain.SeminarGroups.Aggregate;
using University.Infra;
using University.Infra.Query.Classes;

namespace University.Forms.SeminarGroups;

public partial class FrmSeminarGroup : Form
{
    public FrmSeminarGroup()
    {
        InitializeComponent();
        GetClassType();
        GetLesson();
        GetData();
    }

    private void GetLesson()
    {
        ComLesson.BindData(DbContext.Lessons, "Title", "Id");
    }

    private void GetClassType()
    {
        var data = Enum.GetValues(typeof(ClassType))
            .Cast<Enum>()
            .FirstOrDefault()!
            .ToEnumModelList<ClassType, byte>();

        ComClassType.BindData(data, "Title", "Id");
    }

    private void ComClassType_SelectedIndexChanged(object sender, EventArgs e)
    {
        var classType = (ClassType)ComClassType.GetSelectedValue<byte>();
        if (classType == ClassType.FaceToFace)
            textBox1.PlaceholderText = "کلاس حضوری";
        else
            textBox1.PlaceholderText = "لینک";
    }

    private void GetData()
    {
        var data = new ClassQueryService().GetClass();
        dataGridView1.BindingSource(data);
        dataGridView1.Columns.CreateTextBoxColumn("LessonId", "", 0, false);
        dataGridView1.Columns.CreateTextBoxColumn("ClassId", "", 0, false);
        dataGridView1.Columns.CreateTextBoxColumn("LessonName", "نام درس", 150);
        dataGridView1.Columns.CreateTextBoxColumn("ClassType", "نوع کلاس", 150);
        dataGridView1.Columns.CreateTextBoxColumn("LocationOrLink", "محل برگزاری", 200);
        dataGridView1.Columns.CreateTextBoxColumn("Capacity", "ظرفیت", 90);
        dataGridView1.Columns.CreateTextBoxColumn("StartTimeUtc", "شروع", 150);
        dataGridView1.Columns.CreateTextBoxColumn("EndTimeUtc", "پایان", 150);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var capacity = textBox3.ShortValue();
        var classType = ComClassType.GetSelectedValue<ClassType>();

        var lessonId = ComLesson.GetSelectedValue<Guid>();
        if (DbContext.Lessons.All(x => x.Id != lessonId)) throw new Exception("درس انتخابی معتبر نمیباشد");

        if (string.IsNullOrEmpty(textBox1.Text)) throw new Exception(textBox1.PlaceholderText + "$نمتواند خالی باشد");

        var startUtc = new DateTimeOffset(dateTimePicker1.Value, TimeZoneInfo.Local.GetUtcOffset(dateTimePicker1.Value))
            .ToUniversalTime();
        var endUtc = new DateTimeOffset(dateTimePicker2.Value, TimeZoneInfo.Local.GetUtcOffset(dateTimePicker2.Value))
            .ToUniversalTime();

        if (startUtc <= DateTimeOffset.UtcNow)
            throw new InvalidOperationException("زمان شروع کلاس باید در آینده باشد.");

        if (endUtc <= startUtc) throw new InvalidOperationException("زمان پایان کلاس باید بعد از زمان شروع باشد.");

        var hasConflict = DbContext.Classes.Any(c => startUtc < c.EndTimeUtc && endUtc > c.StartTimeUtc);
        if (hasConflict) throw new InvalidOperationException("این بازه زمانی با کلاس دیگری تداخل دارد.");


        var @class = SeminarGroup.Create(lessonId, startUtc, endUtc, capacity, classType, textBox1.Text);
        DbContext.Classes.Add(@class);


        GetData();
    }
}