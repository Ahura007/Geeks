using University.Application.Modules.Query.CommonResult;
using University.Application.Modules.Query.GetModules;
using University.Application.Students.Command.AddModuleToStudent;
using University.Infra.Application;
using University.Infra.Core.Const;
using University.Ui.Extension;

namespace University.Ui.Forms.FrmStudents.Modules;

public partial class FrmAddModuleToStudent : Form
{
    private readonly Guid _id;
    private readonly string _name;

    public FrmAddModuleToStudent(Guid id, string name)
    {
        InitializeComponent();
        _id = id;
        _name = name;
        label1.Text = " انتخاب درس برای دانش آموز  " + name;
        GetData();
    }

    private void GetData()
    {
        var data = new GetModuleQueryHandler().Handle(new GetModuleQuery());
        dataGridView1.ReadOnly = true;
        dataGridView1.BindingSource(data.Data);
        dataGridView1.Columns.CreateCheckBoxColumn(DataGridViewExtension.Select, "انتخاب");
        dataGridView1.Columns.CreateTextBoxColumn("ModuleId", "", false);
        dataGridView1.Columns.CreateTextBoxColumn("ModuleName", "نام درس");
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var selectedItems = dataGridView1.GetCheckedRows<ModuleQr>(DataGridViewExtension.Select);
        if (selectedItems.Count == 0)
            throw new Exception($"هیچ درسی برای انتساب به دانش اموز {_name} انتخاب نشده");


        var result = new AddModuleToStudentCommandHandler().Handle(new AddModuleToStudentCommand
        {
            StudentId = _id,
            ModuleIds = selectedItems.Select(x => x.ModuleId).ToList()
        });

        if (result.State == ApplicationServiceState.Ok)
        {
            MessageBox.Show(Const.Success, Const.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        else
        {
            MessageBox.Show(result.Message, Const.Error, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}