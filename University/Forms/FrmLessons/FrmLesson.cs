using University.Core.Extension;
using University.Domain.Lessons.Aggregate;
using University.Infra;

namespace University.Forms.FrmLessons;

public partial class FrmLesson : Form
{
    public FrmLesson()
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

        var lesson = Lesson.Create(textBox1.Text);
        DbContext.Lessons.Add(lesson);
        GetData();
    }


    private void GetData()
    {
        dataGridView1.BindingSource(DbContext.Lessons);
        dataGridView1.Columns.CreateTextBoxColumn("Id", "شناسه", 250);
        dataGridView1.Columns.CreateTextBoxColumn("Title", "نام  ", 250);
    }
}