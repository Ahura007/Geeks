using University.Application.Students;
using University.Core.Const;
using University.Core.Extension;
using University.Infra.Query.Classes;

namespace University.Forms.FrmStudents;

public partial class FrmAddClassToStudent : Form
{
    private readonly Guid _id;
    private readonly string _name;

    public FrmAddClassToStudent(Guid id, string name)
    {
        InitializeComponent();
        _id = id;
        _name = name;
        label1.Text = " در حال انتخاب کلاس برای دانش آموز " + _name;
        GetClass();
    }

    private void GetClass()
    {
        var data = new ClassQueryService().GetClass();
        dataGridView1.BindingSource(data);
        dataGridView1.Columns.CreateCheckBoxColumn(DataGridViewExtension.Select, "انتخاب");
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
        var selectedItems = dataGridView1.GetCheckedRows<ClassQueryResult>(DataGridViewExtension.Select);
        if (selectedItems.Count == 0)
            throw new Exception($"هیچ کلاسی برای انتساب به دانش اموز {_name} انتخاب نشده");

        var classIds = selectedItems.Select(x => x.ClassId).ToList();
        new RegisterStudentInClassesAppService().Register(_id, classIds);
        MessageBox.Show(Const.SuccessDesc, Const.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        Close();
    }
}