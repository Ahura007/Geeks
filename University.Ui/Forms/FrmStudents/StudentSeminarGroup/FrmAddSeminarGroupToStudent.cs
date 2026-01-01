using University.Application.SeminarGroups.Query.CommonResult;
using University.Application.SeminarGroups.Query.GetSeminarGroup;
using University.Application.Students.Service;
using University.Infra.Core.Const;
using University.Ui.Extension;

namespace University.Ui.Forms.FrmStudents.StudentSeminarGroup;

public partial class FrmAddSeminarGroupToStudent : Form
{
    private readonly Guid _id;
    private readonly string _name;

    public FrmAddSeminarGroupToStudent(Guid id, string name)
    {
        InitializeComponent();
        _id = id;
        _name = name;
        label1.Text = " در حال انتخاب کلاس برای دانش آموز " + _name;
        GetClass();
    }

    private void GetClass()
    {
        var data = new GetSeminarGroupQueryHandler().Handle(new GetSeminarGroupQuery());
        dataGridView1.BindingSource(data.Data);
        dataGridView1.Columns.CreateCheckBoxColumn(DataGridViewExtension.Select, "انتخاب");
        dataGridView1.Columns.CreateTextBoxColumn("ModuleId", "", false);
        dataGridView1.Columns.CreateTextBoxColumn("SeminarGroupId", "", false);
        dataGridView1.Columns.CreateTextBoxColumn("ModuleName", "نام درس");
        dataGridView1.Columns.CreateTextBoxColumn("SeminarGroupType", "نوع کلاس");
        dataGridView1.Columns.CreateTextBoxColumn("LocationOrLink", "محل برگزاری");
        dataGridView1.Columns.CreateTextBoxColumn("Capacity", "ظرفیت");
        dataGridView1.Columns.CreateTextBoxColumn("StartTimeUtc", "شروع");
        dataGridView1.Columns.CreateTextBoxColumn("EndTimeUtc", "پایان");
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var selectedItems = dataGridView1.GetCheckedRows<SeminarGroupQr>(DataGridViewExtension.Select);
        if (selectedItems.Count == 0)
            throw new Exception($"هیچ کلاسی برای انتساب به دانش اموز {_name} انتخاب نشده");

        var seminarGroupIds = selectedItems.Select(x => x.SeminarGroupId).ToList();
        new RegisterStudentInClassesAppService().Register(_id, seminarGroupIds);
        MessageBox.Show(Const.Success, Const.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        Close();
    }
}