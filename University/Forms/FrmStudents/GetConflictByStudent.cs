using University.Core.Extension;
using University.Infra.Query.StudentConflict;

namespace University.Forms.FrmStudents;

public partial class GetConflictByStudent : Form
{
    private readonly Guid _id;

    public GetConflictByStudent(Guid id, string name)
    {
        InitializeComponent();
        _id = id;
        label1.Text = " مشاهده تداخلات دانش آموز " + name;
        GetData();
    }

    private void GetData()
    {
        var data = new StudentConflictQueryService().GetClassByStudentId(_id);
        dataGridView1.BindingSource(data);
        dataGridView1.ReadOnly = true;
        dataGridView1.Columns.CreateTextBoxColumn("LessonId", "", 0, false);
        dataGridView1.Columns.CreateTextBoxColumn("ClassId", "", 0, false);
        dataGridView1.Columns.CreateTextBoxColumn("StudentId", "", 0, false);
        dataGridView1.Columns.CreateTextBoxColumn("LessonTitle", "نام درس", 150);
        dataGridView1.Columns.CreateTextBoxColumn("ConflictType", "نوع تداخل ", 150);
        dataGridView1.Columns.CreateTextBoxColumn("ConflictDate", "تاریخ ثبت تداخل", 200);
        dataGridView1.Columns.CreateTextBoxColumn("ClassStartUtc", "تاریخ شروع کلاس", 200);
        dataGridView1.Columns.CreateTextBoxColumn("ClassEndUtc", "تاریخ پایان کلاس", 200);
    }
}