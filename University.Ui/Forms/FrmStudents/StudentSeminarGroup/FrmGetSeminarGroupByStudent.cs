using University.Application.SeminarGroups.Query.GetSeminarGroupByStudent;
using University.Ui.Extension;

namespace University.Ui.Forms.FrmStudents.StudentSeminarGroup;

public partial class FrmGetSeminarGroupByStudent : Form
{
    private readonly Guid _id;

    public FrmGetSeminarGroupByStudent(Guid id, string name)
    {
        InitializeComponent();
        _id = id;
        label1.Text = " کلاس های انتخاب شده برای دانش اموز " + name;
        GetData();
    }

    private void GetData()
    {
        var data = new GetSeminarGroupByStudentQueryHandler().Handle(new GetSeminarGroupByStudentQuery
        {
            StudentId = _id
        });
        dataGridView1.BindingSource(data.Data);
        dataGridView1.Columns.CreateTextBoxColumn("ModuleId", "", false);
        dataGridView1.Columns.CreateTextBoxColumn("SeminarGroupId", "", false);
        dataGridView1.Columns.CreateTextBoxColumn("ModuleName", "نام درس");
        dataGridView1.Columns.CreateTextBoxColumn("ClassType", "نوع کلاس");
        dataGridView1.Columns.CreateTextBoxColumn("LocationOrLink", "محل برگزاری");
        dataGridView1.Columns.CreateTextBoxColumn("Capacity", "ظرفیت");
        dataGridView1.Columns.CreateTextBoxColumn("StartTimeUtc", "شروع");
        dataGridView1.Columns.CreateTextBoxColumn("EndTimeUtc", "پایان");
    }
}