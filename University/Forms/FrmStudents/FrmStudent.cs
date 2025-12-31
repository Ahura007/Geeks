using University.Core.Extension;
using University.Domain.Students.Aggregate;
using University.Infra;

namespace University.Forms.FrmStudents;

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
        dataGridView1.Columns.CreateTextBoxColumn("Id", "", 0, false);
        dataGridView1.Columns.CreateTextBoxColumn("FullName", "نام  ", 250);
        dataGridView1.Columns.CreateButtonColumn(DataGridViewExtension.AddClassToStudent, "انتخاب کلاس", 150);
        dataGridView1.Columns.CreateButtonColumn(DataGridViewExtension.GetClassByStudent, "کلاس های انتخاب شده", 200);
        dataGridView1.Columns.CreateButtonColumn(DataGridViewExtension.GetConflictByStudent,
            "تاریخچه تداخل انتخاب دروس", 200);
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (!dataGridView1.ValidateOperation(e)) return;
        var id = dataGridView1.GetRowData<Guid>(e, 0);
        var name = dataGridView1.GetRowData<string>(e, 1);

        if (e.ColumnIndex == dataGridView1.Columns[DataGridViewExtension.AddClassToStudent]!.Index)
            new FrmAddClassToStudent(id, name).ShowDialog();

        if (e.ColumnIndex == dataGridView1.Columns[DataGridViewExtension.GetClassByStudent]!.Index)
            new FrmGetClassByStudent(id, name).ShowDialog();

        if (e.ColumnIndex == dataGridView1.Columns[DataGridViewExtension.GetConflictByStudent]!.Index)
            new GetConflictByStudent(id, name).ShowDialog();
    }
}