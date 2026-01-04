using University.Application.Employees.Query.GetEmployee;
using University.Application.Modules.Command.Create;
using University.Application.Modules.Query.GetModules;
using University.Infra.Application;
using University.Infra.Core.Const;
using University.Ui.Extension;

namespace University.Ui.Forms.FrmModules;

public partial class FrmModule : Form
{
    public FrmModule()
    {
        InitializeComponent();
        LoadModulesGrid();
        LoadEmployee();
    }

    private void LoadEmployee()
    {
        var data = new GetEmployeeQueryHandler().Handle(new GetEmployeeQuery());
        cmbResponsibleStaff.BindData(data.Data, "EmployeeName", "EmployeeId");
    }


    private void LoadModulesGrid()
    {
        var data = new GetModuleQueryHandler().Handle(new GetModuleQuery());
        dataGridViewModules.BindingSource(data.Data);
        dataGridViewModules.Columns.CreateTextBoxColumn("ModuleId", "شناسه", false);
        dataGridViewModules.Columns.CreateTextBoxColumn("ModuleName", "نام");
        dataGridViewModules.Columns.CreateTextBoxColumn("Code", "کد");
        dataGridViewModules.Columns.CreateTextBoxColumn("TotalCapacity", "ظرفیت کل");
        dataGridViewModules.Columns.CreateTextBoxColumn("RemainingCapacity", "ظرفیت باقی مانده");
        dataGridViewModules.Columns.CreateTextBoxColumn("UsedCapacity", "ظرفیت استفاده شده توسط دانش آموزان");

        dataGridViewModules.Columns.CreateTextBoxColumn("EmployeeName", "استاد مسئول");
    }


    private void ClearForm()
    {
        txtCode.Clear();
        txtTitle.Clear();
        nudCapacity.Value = 50;
        cmbResponsibleStaff.SelectedIndex = -1;
        errorProvider1.Clear();
        txtCode.Focus();
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        errorProvider1.Clear();


        if (string.IsNullOrWhiteSpace(txtCode.Text))
        {
            errorProvider1.SetError(txtCode, "کد ماژول نمی‌تواند خالی باشد.");
            MessageBox.Show("کد ماژول را وارد کنید.", Const.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCode.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            errorProvider1.SetError(txtTitle, "عنوان ماژول نمی‌تواند خالی باشد.");
            MessageBox.Show("عنوان ماژول را وارد کنید.", Const.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTitle.Focus();
            return;
        }

        if (cmbResponsibleStaff.SelectedIndex == -1)
        {
            errorProvider1.SetError(cmbResponsibleStaff, "لطفاً استاد مسئول را انتخاب کنید.");
            MessageBox.Show("استاد مسئول ماژول را انتخاب کنید.", Const.Warning, MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            cmbResponsibleStaff.Focus();
            return;
        }


        var result = new CreateModuleCommandHandler().Handle(new CreateModuleCommand
        {
            Code = txtCode.Text.Trim(),
            Name = txtTitle.Text.Trim(),
            Capacity = (int)nudCapacity.Value,
            ResponsibleStaffId = cmbResponsibleStaff.GetSelectedValue<Guid>()
        });


        if (result.State == ApplicationServiceState.Ok)
        {
            MessageBox.Show(Const.Success, Const.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();


            LoadModulesGrid();
        }
        else
        {
            MessageBox.Show(result.Message, Const.Error, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void toolStripBtnRefresh_Click(object sender, EventArgs e)
    {
        LoadModulesGrid();
    }
}