using University.Application.Modules.Query.CommonResult;
using University.Application.Modules.Query.GetModules;
using University.Application.Students.Command.AddModuleToStudent;
using University.Application.Students.Query.GetModuleByStudent;
using University.Infra.Application;
using University.Infra.Core.Const;
using University.Ui.Extension;

namespace University.Ui.Forms.FrmStudents;

public partial class FrmStudentModule : Form
{
    private readonly Guid _studentId;
    private readonly string _studentName;
    private List<ModuleQr> _allModules = new();
    private List<Guid> _currentModuleIds = new();

    public FrmStudentModule(Guid studentId, string studentName)
    {
        InitializeComponent();
        _studentId = studentId;
        _studentName = studentName;
        lblTitle.Text = $"مدیریت ماژول‌های دانشجو  {_studentName}";
    }

    private void FrmStudentModules_Load(object sender, EventArgs e)
    {
        LoadModulesGrid();
    }

    private void LoadModulesGrid()
    {
        _allModules = new GetModuleQueryHandler().Handle(new GetModuleQuery()).Data;
        _currentModuleIds = new GetModuleByStudentIdQueryHandler()
            .Handle(new GetModuleByStudentIdQuery { StudentId = _studentId }).Data.Select(x => x.ModuleId).ToList();

        var displayData = _allModules.Select(m => new ModuleDto
        {
            ModuleId = m.ModuleId,
            ModuleName = m.ModuleName,
            Code = m.Code,
            IsRegister = _currentModuleIds.Contains(m.ModuleId),
            RemainingCapacity = m.RemainingCapacity,
            TotalCapacity = m.TotalCapacity,
        }).ToList();

        dataGridViewModules.BindingSource(displayData);
        dataGridViewModules.Columns.CreateTextBoxColumn("Code", "کد ماژول");
        dataGridViewModules.Columns.CreateTextBoxColumn("ModuleName", "نام ماژول");
        dataGridViewModules.Columns.CreateTextBoxColumn("Capacity", "ظرفیت");
        dataGridViewModules.Columns.CreateTextBoxColumn("TotalCapacity", "ظرفیت کل");
        dataGridViewModules.Columns.CreateTextBoxColumn("RemainingCapacity", "ظرفیت باقی مانده");
        dataGridViewModules.Columns.CreateTextBoxColumn("ModuleId", "", false);
        dataGridViewModules.Columns.CreateTextBoxColumn("IsRegister", "", false);
        dataGridViewModules.Columns.CreateCheckBoxColumn(DataGridViewExtension.Select, "انتخاب");
        foreach (DataGridViewRow row in dataGridViewModules.Rows)
        {
            if (row.Cells["IsRegister"].Value is bool isRegister && isRegister)
            {
                var checkBoxCell = row.Cells[DataGridViewExtension.Select] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null)
                {
                    checkBoxCell.Value = true;
                }
            }
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            var selectedModules = dataGridViewModules.GetCheckedRows<dynamic>(DataGridViewExtension.Select);
            var selectedIds = selectedModules.Select(m => (Guid)m.ModuleId).ToList();

            var result = new AddModuleToStudentCommandHandler().Handle(new AddModuleToStudentCommand
            {
                StudentId = _studentId,
                ModuleIds = selectedIds
            });

            if (result.State == ApplicationServiceState.Ok)
            {
                MessageBox.Show("ماژول(ها) با موفقیت به دانشجو اختصاص یافت.", Const.Success, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadModulesGrid();
            }
            else
            {
                MessageBox.Show(result.Message ?? "خطایی رخ داد.", Const.Success, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("خطای غیرمنتظره: " + ex.Message, Const.Success, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}