namespace University.Ui.Forms.FrmStudents
{
    partial class FrmStudentModule
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlMain = new Panel();
            pnlGrid = new Panel();
            dataGridViewModules = new DataGridView();
            pnlButtons = new FlowLayoutPanel();
            btnClose = new Button();
            btnSave = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            errorProvider1 = new ErrorProvider(components);
            pnlMain.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewModules).BeginInit();
            pnlButtons.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(pnlGrid);
            pnlMain.Controls.Add(pnlButtons);
            pnlMain.Controls.Add(pnlHeader);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.RightToLeft = RightToLeft.Yes;
            pnlMain.Size = new Size(1100, 700);
            pnlMain.TabIndex = 0;
            // 
            // pnlGrid
            // 
            pnlGrid.Controls.Add(dataGridViewModules);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(20, 113);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(0, 10, 0, 0);
            pnlGrid.Size = new Size(1060, 482);
            pnlGrid.TabIndex = 0;
            // 
            // dataGridViewModules
            // 
            dataGridViewModules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewModules.Dock = DockStyle.Fill;
            dataGridViewModules.Location = new Point(0, 10);
            dataGridViewModules.MultiSelect = false;
            dataGridViewModules.Name = "dataGridViewModules";
            dataGridViewModules.RightToLeft = RightToLeft.Yes;
            dataGridViewModules.RowHeadersWidth = 60;
            dataGridViewModules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewModules.Size = new Size(1060, 472);
            dataGridViewModules.TabIndex = 0;
            // 
            // pnlButtons
            // 
            pnlButtons.AutoSize = true;
            pnlButtons.Controls.Add(btnClose);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.FlowDirection = FlowDirection.RightToLeft;
            pnlButtons.Location = new Point(20, 595);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(0, 20, 30, 20);
            pnlButtons.Size = new Size(1060, 85);
            pnlButtons.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Tahoma", 10F);
            btnClose.Location = new Point(15, 20);
            btnClose.Margin = new Padding(15, 0, 15, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 45);
            btnClose.TabIndex = 0;
            btnClose.Text = "بستن";
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Tahoma", 10F);
            btnSave.Location = new Point(180, 20);
            btnSave.Margin = new Padding(15, 0, 0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 45);
            btnSave.TabIndex = 1;
            btnSave.Text = "ذخیره تغییرات";
            btnSave.Click += btnSave_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(0, 20, 0, 10);
            pnlHeader.Size = new Size(1060, 93);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Tahoma", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(0, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1060, 49);
            lblTitle.TabIndex = 0;
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmStudentModule
            // 
            ClientSize = new Size(1100, 700);
            Controls.Add(pnlMain);
            Font = new Font("Tahoma", 9.5F);
            MinimumSize = new Size(900, 600);
            Name = "FrmStudentModule";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "مدیریت ماژول‌های دانشجو";
            Load += FrmStudentModules_Load;
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewModules).EndInit();
            pnlButtons.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dataGridViewModules;

        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}