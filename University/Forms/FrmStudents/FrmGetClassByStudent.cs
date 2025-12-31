using University.Core.Extension;
using University.Infra.Query.Classes;

namespace University.Forms.FrmStudents;

public partial class FrmGetClassByStudent : Form
{
    private readonly Guid _id;

    public FrmGetClassByStudent(Guid id, string name)
    {
        InitializeComponent();
        _id = id;
        label1.Text = " کلاس های انتخاب شده برای دانش اموز " + name;
        GetData();
    }

    private void GetData()
    {
        var data = new ClassQueryService().GetClassByStudentId(_id);
        dataGridView1.ReadOnly = true;
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
}