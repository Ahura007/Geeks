using University.Application.Students.Command.Create;
using University.Application.Students.Query.GetStudent;
using University.Infra.Application;
using University.Infra.Core.Const;
using University.Ui.Extension;
using University.Ui.Forms.FrmStudents.Modules;
using University.Ui.Forms.FrmStudents.StudentSeminarGroup;

namespace University.Ui.Forms.FrmStudents;

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
            MessageBox.Show("نام و نام خانوادگی دانش آموز نمیتواند خالی باشد", Const.Error, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        var result = new CreateStudentCommandHandler().Handle(new CreateStudentCommand
        {
            FullName = textBox1.Text
        });

        if (result.State == ApplicationServiceState.Ok)
        {
            MessageBox.Show(Const.Success, Const.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        else
        {
            MessageBox.Show(result.Message, Const.Error, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        GetData();
    }


    private void GetData()
    {
        var data = new GetStudentQueryHandler().Handle(new GetStudentQuery());
        dataGridView1.BindingSource(data.Data);
        dataGridView1.Columns.CreateTextBoxColumn("StudentId", "", false);
        dataGridView1.Columns.CreateTextBoxColumn("StudentName", "نام  ");
        dataGridView1.Columns.CreateButtonColumn(DataGridViewExtension.AddSeminarGroupsToStudent, "انتخاب کلاس");
        dataGridView1.Columns.CreateButtonColumn(DataGridViewExtension.GetSeminarGroupsByStudent,
            "کلاس های انتخاب شده");
        dataGridView1.Columns.CreateButtonColumn(DataGridViewExtension.GetConflictByStudent,
            "تاریخچه تداخل انتخاب دروس");
        dataGridView1.Columns.CreateButtonColumn(DataGridViewExtension.AddModuleToStudent, "انتخاب درس");
        dataGridView1.Columns.CreateButtonColumn(DataGridViewExtension.GetModuleByStudent, "دروس انتخاب شد");
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (!dataGridView1.ValidateOperation(e)) return;
        var id = dataGridView1.GetRowData<Guid>(e, 0);
        var name = dataGridView1.GetRowData<string>(e, 1);

        if (e.ColumnIndex == dataGridView1.Columns[DataGridViewExtension.AddSeminarGroupsToStudent]!.Index)
            new FrmAddSeminarGroupToStudent(id, name).ShowDialog();

        if (e.ColumnIndex == dataGridView1.Columns[DataGridViewExtension.GetSeminarGroupsByStudent]!.Index)
            new FrmGetSeminarGroupByStudent(id, name).ShowDialog();

        if (e.ColumnIndex == dataGridView1.Columns[DataGridViewExtension.GetConflictByStudent]!.Index)
            new GetConflictByStudent(id, name).ShowDialog();

        if (e.ColumnIndex == dataGridView1.Columns[DataGridViewExtension.AddModuleToStudent]!.Index)
            new FrmAddModuleToStudent(id, name).ShowDialog();

        if (e.ColumnIndex == dataGridView1.Columns[DataGridViewExtension.GetModuleByStudent]!.Index)
            new FrmGetModuleByStudent(id, name).ShowDialog();
    }
}