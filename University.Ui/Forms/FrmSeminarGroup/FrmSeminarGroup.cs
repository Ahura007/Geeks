using University.Application.Modules.Query.GetModules;
using University.Application.SeminarGroups.Command.Create;
using University.Application.SeminarGroups.Query.GetSeminarGroup;
using University.Infra.Application;
using University.Infra.Core.Const;
using University.Infra.Core.Enum;
using University.Ui.Extension;

namespace University.Ui.Forms.FrmSeminarGroup;

public partial class FrmSeminarGroup : Form
{
    public FrmSeminarGroup()
    {
        InitializeComponent();
        GetClassType();
        GetModule();
        LoadSeminarGroupsGrid();
        GetDayOfWeek();
    }

    private void GetDayOfWeek()
    {
        var data = Enum.GetValues(typeof(DayOfWeek))
            .Cast<Enum>()
            .FirstOrDefault()!
            .ToEnumModelList<DayOfWeek, byte>();

        cmbDayOfWeek.BindData(data, "Title", "Id");
    }

    private void GetModule()
    {
        var data = new GetModuleQueryHandler().Handle(new GetModuleQuery());
        cmbModule.BindData(data.Data, "ModuleName", "ModuleId");
    }

    private void GetClassType()
    {
        var data = Enum.GetValues(typeof(SeminarGroupType))
            .Cast<Enum>()
            .FirstOrDefault()!
            .ToEnumModelList<SeminarGroupType, byte>();

        cmbClassType.BindData(data, "Title", "Id");
    }


    private void ClearForm()
    {
        cmbModule.SelectedIndex = -1;
        cmbDayOfWeek.SelectedIndex = -1;
        dtpStartTime.Value = DateTime.Today.AddHours(8);
        dtpEndTime.Value = DateTime.Today.AddHours(10);
        nudCapacity.Value = 30;
        cmbClassType.SelectedIndex = -1;
        txtLocation.Clear();
        errorProvider1.Clear();
        cmbModule.Focus();
    }

    private void LoadSeminarGroupsGrid()
    {
        var data = new GetSeminarGroupQueryHandler().Handle(new GetSeminarGroupQuery());
        dataGridViewSeminarGroups.BindingSource(data.Data);
        dataGridViewSeminarGroups.Columns.CreateTextBoxColumn("ModuleId", "", false);
        dataGridViewSeminarGroups.Columns.CreateTextBoxColumn("SeminarGroupId", "", false);
        dataGridViewSeminarGroups.Columns.CreateTextBoxColumn("ModuleName", "نام درس");
        dataGridViewSeminarGroups.Columns.CreateTextBoxColumn("SeminarGroupType", "نوع کلاس");
        dataGridViewSeminarGroups.Columns.CreateTextBoxColumn("DayOfWeek", "روز هفته");
        dataGridViewSeminarGroups.Columns.CreateTextBoxColumn("LocationOrLink", "محل برگزاری");
        dataGridViewSeminarGroups.Columns.CreateTextBoxColumn("ModuleCapacity", "ظرفیت کل درس");
        dataGridViewSeminarGroups.Columns.CreateTextBoxColumn("Capacity", "ظرفیت کلاس");
        dataGridViewSeminarGroups.Columns.CreateTextBoxColumn("RemainingCapacity", "ظرفیت باقی مانده کلاس");
        dataGridViewSeminarGroups.Columns.CreateTextBoxColumn("StartTime", "شروع");
        dataGridViewSeminarGroups.Columns.CreateTextBoxColumn("EndTime", "پایان");
    }


    private void btnRegister_Click(object sender, EventArgs e)
    {
        errorProvider1.Clear();

        if (cmbModule.SelectedIndex == -1)
        {
            errorProvider1.SetError(cmbModule, "لطفاً ماژول را انتخاب کنید.");
            MessageBox.Show("ماژول را انتخاب کنید.", Const.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbModule.Focus();
            return;
        }

        if (cmbDayOfWeek.SelectedIndex == -1)
        {
            errorProvider1.SetError(cmbDayOfWeek, "روز هفته را انتخاب کنید.");
            MessageBox.Show("روز هفته را انتخاب کنید.", Const.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbDayOfWeek.Focus();
            return;
        }

        if (cmbClassType.SelectedIndex == -1)
        {
            errorProvider1.SetError(cmbClassType, "نوع کلاس را انتخاب کنید.");
            MessageBox.Show("نوع کلاس را انتخاب کنید.", Const.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbClassType.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtLocation.Text))
        {
            errorProvider1.SetError(txtLocation, "محل یا لینک کلاس نمی‌تواند خالی باشد.");
            MessageBox.Show("محل یا لینک کلاس را وارد کنید.", Const.Warning, MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtLocation.Focus();
            return;
        }

        if (nudCapacity.Value <= 0)
        {
            errorProvider1.SetError(nudCapacity, "ظرفیت باید بزرگ‌تر از صفر باشد.");
            MessageBox.Show("ظرفیت معتبر وارد کنید.", Const.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nudCapacity.Focus();
            return;
        }

        var moduleId = cmbModule.GetSelectedValue<Guid>();
        var dayOfWeek = cmbDayOfWeek.GetSelectedValue<DayOfWeek>();
        var seminarGroupType = cmbClassType.GetSelectedValue<SeminarGroupType>();
        var locationOrLink = txtLocation.Text.Trim();
        var startTime = dtpStartTime.Value.TimeOfDay;
        var endTime = dtpEndTime.Value.TimeOfDay;
        var capacity = (short)nudCapacity.Value;

        if (string.IsNullOrEmpty(locationOrLink))
            throw new Exception(txtLocation.PlaceholderText + "$نمتواند خالی باشد");

        if (endTime <= startTime)
        {
            errorProvider1.SetError(dtpEndTime, "زمان پایان باید بعد از زمان شروع باشد.");
            MessageBox.Show("زمان پایان کلاس باید بعد از زمان شروع باشد.", Const.Warning, MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            dtpEndTime.Focus();
            return;
        }


        if (seminarGroupType == SeminarGroupType.Virtual)
            if (!Uri.TryCreate(locationOrLink, UriKind.Absolute, out var uriResult) ||
                (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                errorProvider1.SetError(txtLocation, "برای کلاس مجازی، لینک معتبر (http/https) وارد کنید.");
                MessageBox.Show("لینک کلاس مجازی معتبر نیست.", Const.Warning, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

        var result = new CreateSeminarGroupCommandHandler().Handle(new CreateSeminarGroupCommand
        {
            ModuleId = moduleId,
            DayOfWeek = dayOfWeek,
            StartTime = startTime,
            EndTime = endTime,
            Capacity = capacity,
            SeminarGroupType = seminarGroupType,
            LocationOrLink = locationOrLink
        });

        if (result.State == ApplicationServiceState.Ok)
        {
            MessageBox.Show(
                $"گروه سمینار برای ماژول «{cmbModule.Text}» در روز {dayOfWeek} از {startTime} تا {endTime} با موفقیت ثبت شد.",
                "ثبت موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            LoadSeminarGroupsGrid();
        }
        else
        {
            MessageBox.Show(result.Message, Const.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}