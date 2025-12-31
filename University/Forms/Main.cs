using University.Forms.FrmClasses;
using University.Forms.FrmLessons;
using University.Forms.FrmStudents;

namespace University.Forms;

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

    private void BtnLesson_Click(object sender, EventArgs e)
    {
        new FrmLesson().ShowDialog();
    }

    private void BtnClass_Click(object sender, EventArgs e)
    {
        new FrmClass().ShowDialog();
    }
}