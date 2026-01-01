using University.Application.Modules.Query.GetModules;
using University.Ui.Extension;

namespace University.Ui.Forms.FrmModules;

public partial class FrmModule : Form
{
    public FrmModule()
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

        //var module = Module.Create(textBox1.Text);
        //DbContext.Modules.Add(module);
        GetData();
    }


    private void GetData()
    {
        var data = new GetModuleQueryHandler().Handle(new GetModuleQuery());
        dataGridView1.BindingSource(data.Data);
        dataGridView1.Columns.CreateTextBoxColumn("Id", "شناسه");
        dataGridView1.Columns.CreateTextBoxColumn("Title", "نام  ");
    }
}