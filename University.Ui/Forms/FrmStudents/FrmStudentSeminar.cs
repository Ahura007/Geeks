using University.Application.SeminarGroups.Query.CommonResult;
using University.Application.SeminarGroups.Query.GetAvailableSeminarGroupByStudent;
using University.Application.SeminarGroups.Query.GetSeminarGroupByStudent;
using University.Application.Students.Service;
using University.Ui.Extension;

namespace University.Ui.Forms.FrmStudents;

public partial class FrmStudentSeminar : Form
{
    private readonly Guid _studentId;
    private readonly string _studentName;
    private List<SeminarGroupQr> _allSeminars = new();
    private List<Guid> _currentSeminarIds = new();

    public FrmStudentSeminar(Guid studentId, string studentName)
    {
        InitializeComponent();
        _studentId = studentId;
        _studentName = studentName;
        lblTitle.Text = $"مدیریت گروه‌های سمینار — دانشجو  {_studentName}";
    }

    private void FrmStudentSeminars_Load(object sender, EventArgs e)
    {
        LoadSeminarsGrid();
    }

    private void LoadSeminarsGrid()
    {
        _allSeminars = new GetAvailableSeminarGroupByStudentQueryHandler().Handle(new GetAvailableSeminarGroupByStudentQuery()
        {
            StudentId = _studentId
        }).Data.ToList();

        _currentSeminarIds = new GetSeminarGroupByStudentQueryHandler().Handle(new GetSeminarGroupByStudentQuery
        {
            StudentId = _studentId
        }).Data.Select(x => x.SeminarGroupId).ToList();

        var displayData = _allSeminars.Select(s => new SeminarGroupDto
        {
            SeminarGroupId = s.SeminarGroupId,
            ModuleId = s.ModuleId,
            ModuleName = s.ModuleName,
            SeminarGroupType = s.SeminarGroupType,
            LocationOrLink = s.LocationOrLink,
            Capacity = s.Capacity,
            StartTime = s.StartTime,
            EndTime = s.EndTime,
            DayOfWeek = s.DayOfWeek.ToString(),
            IsRegistered = _currentSeminarIds.Contains(s.SeminarGroupId),
            RemainingCapacity = s.RemainingCapacity

        }).ToList();

        dataGridViewSeminars.BindingSource(displayData);
        dataGridViewSeminars.Columns.CreateTextBoxColumn("ModuleName", "نام درس");
        dataGridViewSeminars.Columns.CreateTextBoxColumn("DayOfWeek", "روز هفته");
        dataGridViewSeminars.Columns.CreateTextBoxColumn("StartTime", "ساعت شروع");
        dataGridViewSeminars.Columns.CreateTextBoxColumn("EndTime", "ساعت پایان");
        dataGridViewSeminars.Columns.CreateTextBoxColumn("SeminarGroupType", "نوع کلاس");
        dataGridViewSeminars.Columns.CreateTextBoxColumn("LocationOrLink", "محل/لینک");
        dataGridViewSeminars.Columns.CreateTextBoxColumn("Capacity", "ظرفیت");
        dataGridViewSeminars.Columns.CreateTextBoxColumn("RemainingCapacity", "ظرفیت باقی مانده");
        dataGridViewSeminars.Columns.CreateTextBoxColumn("SeminarGroupId", "", false);
        dataGridViewSeminars.Columns.CreateTextBoxColumn("ModuleId", "", false);
        dataGridViewSeminars.Columns.CreateTextBoxColumn("IsRegistered", "", false);
        dataGridViewSeminars.Columns.CreateCheckBoxColumn(DataGridViewExtension.Select, "انتخاب");


        foreach (DataGridViewRow row in dataGridViewSeminars.Rows)
        {
            if (row.Cells["IsRegistered"].Value is bool isRegister && isRegister)
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
        var checkedRows = dataGridViewSeminars.GetCheckedRows<SeminarGroupDto>(DataGridViewExtension.Select);
        var selectedSeminarIds = checkedRows.Select(r => (Guid)r.SeminarGroupId).ToList();

        new RegisterStudentInClassesAppService().Register(_studentId, selectedSeminarIds);

        MessageBox.Show("گروه‌های سمینار با موفقیت برای دانشجو ثبت شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
        LoadSeminarsGrid();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}