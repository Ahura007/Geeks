using University.Application.Modules.Query.GetModules;
using University.Application.SeminarGroups.Query.GetSeminarGroup;
using University.Infra.Core.Enum;
using University.Ui.Extension;

namespace University.Ui.Forms.SeminarGroups;

public partial class FrmSeminarGroup : Form
{
    public FrmSeminarGroup()
    {
        InitializeComponent();
        GetClassType();
        GetModule();
        GetData();
    }

    private void GetModule()
    {
        var data = new GetModuleQueryHandler().Handle(new GetModuleQuery());
        ComModule.BindData(data.Data, "Title", "Id");
    }

    private void GetClassType()
    {
        var data = Enum.GetValues(typeof(SeminarGroupType))
            .Cast<Enum>()
            .FirstOrDefault()!
            .ToEnumModelList<SeminarGroupType, byte>();

        ComClassType.BindData(data, "Title", "Id");
    }

    private void ComClassType_SelectedIndexChanged(object sender, EventArgs e)
    {
        var classType = (SeminarGroupType)ComClassType.GetSelectedValue<byte>();
        if (classType == SeminarGroupType.FaceToFace)
            textBox1.PlaceholderText = "کلاس حضوری";
        else
            textBox1.PlaceholderText = "لینک";
    }

    private void GetData()
    {
        var data = new GetSeminarGroupQueryHandler().Handle(new GetSeminarGroupQuery());
        dataGridView1.BindingSource(data.Data);
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
        var capacity = textBox3.ShortValue();
        var classType = ComClassType.GetSelectedValue<SeminarGroupType>();

        var moduleId = ComModule.GetSelectedValue<Guid>();
        var modules = new GetModuleQueryHandler().Handle(new GetModuleQuery());
        if (modules.Data.All(x => x.ModuleId != moduleId))
            throw new Exception("درس انتخابی معتبر نمیباشد");

        if (string.IsNullOrEmpty(textBox1.Text)) throw new Exception(textBox1.PlaceholderText + "$نمتواند خالی باشد");

        var startUtc = new DateTimeOffset(dateTimePicker1.Value, TimeZoneInfo.Local.GetUtcOffset(dateTimePicker1.Value))
            .ToUniversalTime();
        var endUtc = new DateTimeOffset(dateTimePicker2.Value, TimeZoneInfo.Local.GetUtcOffset(dateTimePicker2.Value))
            .ToUniversalTime();

        if (startUtc <= DateTimeOffset.UtcNow)
            throw new InvalidOperationException("زمان شروع کلاس باید در آینده باشد.");

        if (endUtc <= startUtc) throw new InvalidOperationException("زمان پایان کلاس باید بعد از زمان شروع باشد.");

        //var hasConflict = DbContext.SeminarGroups.Any(c => startUtc < c.EndTimeUtc && endUtc > c.StartTimeUtc);
        //if (hasConflict) throw new InvalidOperationException("این بازه زمانی با کلاس دیگری تداخل دارد.");


        //var @class = SeminarGroup.Create(moduleId, startUtc, endUtc, capacity, classType, textBox1.Text);
        //DbContext.SeminarGroups.Add(@class);


        GetData();
    }
}