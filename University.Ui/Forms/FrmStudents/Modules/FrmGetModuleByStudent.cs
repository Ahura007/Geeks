namespace University.Ui.Forms.FrmStudents.Modules;

public partial class FrmGetModuleByStudent : Form
{
    private readonly Guid _id;
    private readonly string _name;

    public FrmGetModuleByStudent(Guid id, string name)
    {
        InitializeComponent();
        _id = id;
        _name = name;
        label1.Text = " انتخاب درس برای دانش آموز  " + name;
    }
}