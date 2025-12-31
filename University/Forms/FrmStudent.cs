using University.Core.Extension;
using University.Domain.Students.Aggregate;
using University.Infra;

namespace University.Forms;

public partial class FrmStudent : Form
{
    public FrmStudent()
    {
        InitializeComponent();
        GetData();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(textBox1.Text))
        {
            MessageBox.Show("هشدار", " نام و نام خانوادگی دانش آموز نمیتواند خالی باشد");
            return;
        }

        var student = Student.Create(textBox1.Text);
        DbContext.Students.Add(student);
        GetData();
    }


    private void GetData()
    {
        dataGridView1.BindingSource(DbContext.Students);
        dataGridView1.Columns.CreateTextBoxColumn("Id", "شناسه", 250);
        dataGridView1.Columns.CreateTextBoxColumn("FullName", "نام  ", 250);
    }
}

