namespace University.Ui.Forms.FrmModules
{
    partial class FrmModule
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
            toolStripMain = new ToolStrip();
            toolStripBtnRefresh = new ToolStripButton();
            pnlMain = new Panel();
            pnlGrid = new Panel();
            dataGridViewModules = new DataGridView();
            pnlForm = new Panel();
            flowButtons = new FlowLayoutPanel();
            btnClear = new Button();
            btnRegister = new Button();
            tableLayoutMain = new TableLayoutPanel();
            lblCode = new Label();
            txtCode = new TextBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblCapacity = new Label();
            nudCapacity = new NumericUpDown();
            lblResponsibleStaff = new Label();
            cmbResponsibleStaff = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            toolStripMain.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewModules).BeginInit();
            pnlForm.SuspendLayout();
            flowButtons.SuspendLayout();
            tableLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCapacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // toolStripMain
            // 
            toolStripMain.Items.AddRange(new ToolStripItem[] { toolStripBtnRefresh });
            toolStripMain.Location = new Point(0, 0);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.RightToLeft = RightToLeft.Yes;
            toolStripMain.Size = new Size(884, 25);
            toolStripMain.TabIndex = 0;
            // 
            // toolStripBtnRefresh
            // 
            toolStripBtnRefresh.Name = "toolStripBtnRefresh";
            toolStripBtnRefresh.Size = new Size(92, 22);
            toolStripBtnRefresh.Text = "بروزرسانی لیست";
            toolStripBtnRefresh.Click += toolStripBtnRefresh_Click;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(pnlGrid);
            pnlMain.Controls.Add(pnlForm);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 25);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.RightToLeft = RightToLeft.Yes;
            pnlMain.Size = new Size(884, 725);
            pnlMain.TabIndex = 0;
            // 
            // pnlGrid
            // 
            pnlGrid.Controls.Add(dataGridViewModules);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(20, 335);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(0, 20, 0, 20);
            pnlGrid.Size = new Size(844, 370);
            pnlGrid.TabIndex = 0;
            // 
            // dataGridViewModules
            // 
            dataGridViewModules.AllowUserToAddRows = false;
            dataGridViewModules.AllowUserToDeleteRows = false;
            dataGridViewModules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewModules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewModules.Dock = DockStyle.Fill;
            dataGridViewModules.Location = new Point(0, 20);
            dataGridViewModules.MultiSelect = false;
            dataGridViewModules.Name = "dataGridViewModules";
            dataGridViewModules.ReadOnly = true;
            dataGridViewModules.RightToLeft = RightToLeft.Yes;
            dataGridViewModules.RowHeadersWidth = 60;
            dataGridViewModules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewModules.Size = new Size(844, 330);
            dataGridViewModules.TabIndex = 0;
            // 
            // pnlForm
            // 
            pnlForm.AutoSize = true;
            pnlForm.Controls.Add(flowButtons);
            pnlForm.Controls.Add(tableLayoutMain);
            pnlForm.Dock = DockStyle.Top;
            pnlForm.Location = new Point(20, 20);
            pnlForm.Name = "pnlForm";
            pnlForm.Padding = new Padding(0, 0, 0, 30);
            pnlForm.RightToLeft = RightToLeft.Yes;
            pnlForm.Size = new Size(844, 315);
            pnlForm.TabIndex = 1;
            // 
            // flowButtons
            // 
            flowButtons.AutoSize = true;
            flowButtons.Controls.Add(btnClear);
            flowButtons.Controls.Add(btnRegister);
            flowButtons.Dock = DockStyle.Top;
            flowButtons.FlowDirection = FlowDirection.RightToLeft;
            flowButtons.Location = new Point(0, 220);
            flowButtons.Name = "flowButtons";
            flowButtons.Padding = new Padding(0, 20, 30, 0);
            flowButtons.Size = new Size(844, 65);
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
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Tahoma", 9.5F);
            btnRegister.Location = new Point(180, 20);
            btnRegister.Margin = new Padding(15, 0, 15, 0);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 45);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "ثبت ماژول";
            btnRegister.Click += btnRegister_Click;
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.AutoSize = true;
            tableLayoutMain.ColumnCount = 2;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle());
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(lblCode, 0, 0);
            tableLayoutMain.Controls.Add(txtCode, 1, 0);
            tableLayoutMain.Controls.Add(lblTitle, 0, 1);
            tableLayoutMain.Controls.Add(txtTitle, 1, 1);
            tableLayoutMain.Controls.Add(lblCapacity, 0, 2);
            tableLayoutMain.Controls.Add(nudCapacity, 1, 2);
            tableLayoutMain.Controls.Add(lblResponsibleStaff, 0, 3);
            tableLayoutMain.Controls.Add(cmbResponsibleStaff, 1, 3);
            tableLayoutMain.Dock = DockStyle.Top;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.Padding = new Padding(10, 10, 30, 10);
            tableLayoutMain.RightToLeft = RightToLeft.Yes;
            tableLayoutMain.RowCount = 4;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutMain.Size = new Size(844, 220);
            tableLayoutMain.TabIndex = 1;
            // 
            // lblCode
            // 
            lblCode.Anchor = AnchorStyles.Right;
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            lblCode.Location = new Point(677, 27);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(65, 16);
            lblCode.TabIndex = 0;
            lblCode.Text = "کد ماژول:";
            lblCode.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            txtCode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtCode.Font = new Font("Tahoma", 9.5F);
            txtCode.Location = new Point(13, 23);
            txtCode.Name = "txtCode";
            txtCode.PlaceholderText = "مثال: CS101";
            txtCode.Size = new Size(658, 23);
            txtCode.TabIndex = 1;
            txtCode.TextAlign = HorizontalAlignment.Right;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            lblTitle.Location = new Point(677, 77);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(86, 16);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "عنوان ماژول:";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTitle
            // 
            txtTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTitle.Font = new Font("Tahoma", 9.5F);
            txtTitle.Location = new Point(13, 73);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "نام کامل ماژول";
            txtTitle.Size = new Size(658, 23);
            txtTitle.TabIndex = 3;
            txtTitle.TextAlign = HorizontalAlignment.Right;
            // 
            // lblCapacity
            // 
            lblCapacity.Anchor = AnchorStyles.Right;
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            lblCapacity.Location = new Point(677, 127);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(116, 16);
            lblCapacity.TabIndex = 4;
            lblCapacity.Text = "ظرفیت کل ماژول:";
            lblCapacity.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudCapacity
            // 
            nudCapacity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudCapacity.Font = new Font("Tahoma", 9.5F);
            nudCapacity.Location = new Point(13, 123);
            nudCapacity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacity.Name = "nudCapacity";
            nudCapacity.Size = new Size(658, 23);
            nudCapacity.TabIndex = 5;
            nudCapacity.TextAlign = HorizontalAlignment.Center;
            nudCapacity.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblResponsibleStaff
            // 
            lblResponsibleStaff.Anchor = AnchorStyles.Right;
            lblResponsibleStaff.AutoSize = true;
            lblResponsibleStaff.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            lblResponsibleStaff.Location = new Point(677, 177);
            lblResponsibleStaff.Name = "lblResponsibleStaff";
            lblResponsibleStaff.Size = new Size(134, 16);
            lblResponsibleStaff.TabIndex = 6;
            lblResponsibleStaff.Text = "استاد مسئول ماژول:";
            lblResponsibleStaff.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbResponsibleStaff
            // 
            cmbResponsibleStaff.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbResponsibleStaff.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResponsibleStaff.Font = new Font("Tahoma", 9.5F);
            cmbResponsibleStaff.Location = new Point(13, 173);
            cmbResponsibleStaff.Name = "cmbResponsibleStaff";
            cmbResponsibleStaff.Size = new Size(658, 24);
            cmbResponsibleStaff.TabIndex = 7;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmModule
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 750);
            Controls.Add(pnlMain);
            Controls.Add(toolStripMain);
            Font = new Font("Tahoma", 9.5F);
            MinimumSize = new Size(900, 600);
            Name = "FrmModule";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "مدیریت ماژول‌های دانشگاهی";
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewModules).EndInit();
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            flowButtons.ResumeLayout(false);
            tableLayoutMain.ResumeLayout(false);
            tableLayoutMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCapacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripBtnRefresh;

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.Label lblResponsibleStaff;
        private System.Windows.Forms.ComboBox cmbResponsibleStaff;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRegister;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dataGridViewModules;

        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}