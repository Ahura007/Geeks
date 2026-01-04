namespace University.Ui.Forms.FrmStudents
{
    partial class FrmStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            dataGridViewStudents = new DataGridView();
            pnlForm = new Panel();
            flowButtons = new FlowLayoutPanel();
            btnClear = new Button();
            btnRegister = new Button();
            tableLayoutForm = new TableLayoutPanel();
            lblFullName = new Label();
            txtFullName = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            pnlMain.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            pnlForm.SuspendLayout();
            flowButtons.SuspendLayout();
            tableLayoutForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(pnlGrid);
            pnlMain.Controls.Add(pnlForm);
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
            pnlGrid.Controls.Add(dataGridViewStudents);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(20, 205);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(0, 20, 0, 20);
            pnlGrid.Size = new Size(1060, 475);
            pnlGrid.TabIndex = 0;
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.AllowUserToDeleteRows = false;
            dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Dock = DockStyle.Fill;
            dataGridViewStudents.Location = new Point(0, 20);
            dataGridViewStudents.MultiSelect = false;
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.RightToLeft = RightToLeft.Yes;
            dataGridViewStudents.RowHeadersWidth = 60;
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.Size = new Size(1060, 435);
            dataGridViewStudents.TabIndex = 0;
            dataGridViewStudents.CellClick += dataGridViewStudents_CellClick;
            // 
            // pnlForm
            // 
            pnlForm.AutoSize = true;
            pnlForm.Controls.Add(flowButtons);
            pnlForm.Controls.Add(tableLayoutForm);
            pnlForm.Dock = DockStyle.Top;
            pnlForm.Location = new Point(20, 20);
            pnlForm.Name = "pnlForm";
            pnlForm.Padding = new Padding(0, 0, 0, 30);
            pnlForm.RightToLeft = RightToLeft.Yes;
            pnlForm.Size = new Size(1060, 185);
            pnlForm.TabIndex = 1;
            // 
            // flowButtons
            // 
            flowButtons.AutoSize = true;
            flowButtons.Controls.Add(btnClear);
            flowButtons.Controls.Add(btnRegister);
            flowButtons.Dock = DockStyle.Top;
            flowButtons.FlowDirection = FlowDirection.RightToLeft;
            flowButtons.Location = new Point(0, 90);
            flowButtons.Name = "flowButtons";
            flowButtons.Padding = new Padding(0, 20, 30, 0);
            flowButtons.Size = new Size(1060, 65);
            flowButtons.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Tahoma", 9.5F);
            btnClear.Location = new Point(0, 20);
            btnClear.Margin = new Padding(15, 0, 0, 0);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 45);
            btnClear.TabIndex = 0;
            btnClear.Text = "پاک کردن فرم";
            btnClear.Click += btnClear_Click;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Tahoma", 9.5F);
            btnRegister.Location = new Point(180, 20);
            btnRegister.Margin = new Padding(15, 0, 15, 0);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 45);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "ثبت دانشجو";
            btnRegister.Click += btnRegister_Click;
            // 
            // tableLayoutForm
            // 
            tableLayoutForm.AutoSize = true;
            tableLayoutForm.ColumnCount = 2;
            tableLayoutForm.ColumnStyles.Add(new ColumnStyle());
            tableLayoutForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutForm.Controls.Add(lblFullName, 0, 0);
            tableLayoutForm.Controls.Add(txtFullName, 1, 0);
            tableLayoutForm.Dock = DockStyle.Top;
            tableLayoutForm.Location = new Point(0, 0);
            tableLayoutForm.Name = "tableLayoutForm";
            tableLayoutForm.Padding = new Padding(10, 20, 30, 10);
            tableLayoutForm.RightToLeft = RightToLeft.Yes;
            tableLayoutForm.RowCount = 1;
            tableLayoutForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutForm.Size = new Size(1060, 90);
            tableLayoutForm.TabIndex = 1;
            // 
            // lblFullName
            // 
            lblFullName.Anchor = AnchorStyles.Right;
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            lblFullName.Location = new Point(854, 42);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(173, 16);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "نام و نام خانوادگی دانشجو:";
            lblFullName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtFullName
            // 
            txtFullName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtFullName.Font = new Font("Tahoma", 9.5F);
            txtFullName.Location = new Point(13, 38);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "مثال: علی احمدی";
            txtFullName.Size = new Size(835, 23);
            txtFullName.TabIndex = 1;
            txtFullName.TextAlign = HorizontalAlignment.Right;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(pnlMain);
            Font = new Font("Tahoma", 9.5F);
            MinimumSize = new Size(900, 600);
            Name = "FrmStudent";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "مدیریت دانشجویان";
            Load += FrmStudent_Load;
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            flowButtons.ResumeLayout(false);
            tableLayoutForm.ResumeLayout(false);
            tableLayoutForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutForm;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRegister;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dataGridViewStudents;

        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}