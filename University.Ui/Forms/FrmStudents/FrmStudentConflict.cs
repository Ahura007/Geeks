using University.Application.Students.Query.GetStudentConflict;
using University.Ui.Extension;

namespace University.Ui.Forms.FrmStudents;

public partial class FrmStudentConflict : Form
{
    private readonly Guid _id;

    public FrmStudentConflict(Guid id, string name)
    {
        InitializeComponent();
        _id = id;
        label1.Text = " مشاهده تداخلات دانش آموز " + name;
        GetData();
    }

    private void GetData()
    {
        var data = new GetStudentConflictQueryHandler().Handle(new GetStudentConflictQuery
        {
            StudentId = _id
        });
        dataGridView1.BindingSource(data.Data);
        dataGridView1.ReadOnly = true;
        dataGridView1.Columns.CreateTextBoxColumn("ModuleId", "", false);
        dataGridView1.Columns.CreateTextBoxColumn("SeminarGroupId", "", false);
        dataGridView1.Columns.CreateTextBoxColumn("StudentId", "", false);
        dataGridView1.Columns.CreateTextBoxColumn("ModuleName", "نام درس");
        dataGridView1.Columns.CreateTextBoxColumn("ConflictType", "نوع تداخل ");
        dataGridView1.Columns.CreateTextBoxColumn("ConflictDate", "تاریخ ثبت تداخل");
        dataGridView1.Columns.CreateTextBoxColumn("StartTime", "تاریخ شروع کلاس");
        dataGridView1.Columns.CreateTextBoxColumn("EndTime", "تاریخ پایان کلاس");
    }
}