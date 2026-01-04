using University.Ui.Forms.FrmModules;
using University.Ui.Forms.FrmSeminarGroup;
using University.Ui.Forms.FrmStudents;

namespace University.Ui;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
    }

    private void BtnStudent_Click(object sender, EventArgs e)
    {
        new FrmStudent().ShowDialog();
    }

    private void BtnModule_Click(object sender, EventArgs e)
    {
        new FrmModule().ShowDialog();
    }

    private void BtnClass_Click(object sender, EventArgs e)
    {
        new FrmSeminarGroup().ShowDialog();
    }
}