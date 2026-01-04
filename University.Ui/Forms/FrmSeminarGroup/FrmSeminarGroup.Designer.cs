namespace University.Ui.Forms.FrmSeminarGroup
{
    partial class FrmSeminarGroup
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
            dataGridViewSeminarGroups = new DataGridView();
            pnlForm = new Panel();
            flowButtons = new FlowLayoutPanel();
            btnClear = new Button();
            btnRegister = new Button();
            tableLayoutMain = new TableLayoutPanel();
            lblModule = new Label();
            cmbModule = new ComboBox();
            lblDayOfWeek = new Label();
            cmbDayOfWeek = new ComboBox();
            lblStartTime = new Label();
            dtpStartTime = new DateTimePicker();
            lblEndTime = new Label();
            dtpEndTime = new DateTimePicker();
            lblCapacity = new Label();
            nudCapacity = new NumericUpDown();
            lblClassType = new Label();
            cmbClassType = new ComboBox();
            lblLocation = new Label();
            txtLocation = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            toolStripMain.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSeminarGroups).BeginInit();
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
            toolStripMain.Size = new Size(1203, 25);
            toolStripMain.TabIndex = 0;
            // 
            // toolStripBtnRefresh
            // 
            toolStripBtnRefresh.Name = "toolStripBtnRefresh";
            toolStripBtnRefresh.Size = new Size(92, 22);
            toolStripBtnRefresh.Text = "بروزرسانی لیست";
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
            pnlMain.Size = new Size(1203, 725);
            pnlMain.TabIndex = 0;
            // 
            // pnlGrid
            // 
            pnlGrid.Controls.Add(dataGridViewSeminarGroups);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(20, 485);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(0, 20, 0, 20);
            pnlGrid.Size = new Size(1163, 220);
            pnlGrid.TabIndex = 0;
            // 
            // dataGridViewSeminarGroups
            // 
            dataGridViewSeminarGroups.AllowUserToAddRows = false;
            dataGridViewSeminarGroups.AllowUserToDeleteRows = false;
            dataGridViewSeminarGroups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSeminarGroups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSeminarGroups.Dock = DockStyle.Fill;
            dataGridViewSeminarGroups.Location = new Point(0, 20);
            dataGridViewSeminarGroups.MultiSelect = false;
            dataGridViewSeminarGroups.Name = "dataGridViewSeminarGroups";
            dataGridViewSeminarGroups.ReadOnly = true;
            dataGridViewSeminarGroups.RightToLeft = RightToLeft.Yes;
            dataGridViewSeminarGroups.RowHeadersWidth = 60;
            dataGridViewSeminarGroups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSeminarGroups.Size = new Size(1163, 180);
            dataGridViewSeminarGroups.TabIndex = 0;
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
            pnlForm.Size = new Size(1163, 465);
            pnlForm.TabIndex = 1;
            // 
            // flowButtons
            // 
            flowButtons.AutoSize = true;
            flowButtons.Controls.Add(btnClear);
            flowButtons.Controls.Add(btnRegister);
            flowButtons.Dock = DockStyle.Top;
            flowButtons.FlowDirection = FlowDirection.RightToLeft;
            flowButtons.Location = new Point(0, 370);
            flowButtons.Name = "flowButtons";
            flowButtons.Padding = new Padding(0, 20, 30, 0);
            flowButtons.Size = new Size(1163, 65);
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
            btnRegister.Text = "ثبت گروه سمینار";
            btnRegister.Click += btnRegister_Click;
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.AutoSize = true;
            tableLayoutMain.ColumnCount = 2;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle());
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(lblModule, 0, 0);
            tableLayoutMain.Controls.Add(cmbModule, 1, 0);
            tableLayoutMain.Controls.Add(lblDayOfWeek, 0, 1);
            tableLayoutMain.Controls.Add(cmbDayOfWeek, 1, 1);
            tableLayoutMain.Controls.Add(lblStartTime, 0, 2);
            tableLayoutMain.Controls.Add(dtpStartTime, 1, 2);
            tableLayoutMain.Controls.Add(lblEndTime, 0, 3);
            tableLayoutMain.Controls.Add(dtpEndTime, 1, 3);
            tableLayoutMain.Controls.Add(lblCapacity, 0, 4);
            tableLayoutMain.Controls.Add(nudCapacity, 1, 4);
            tableLayoutMain.Controls.Add(lblClassType, 0, 5);
            tableLayoutMain.Controls.Add(cmbClassType, 1, 5);
            tableLayoutMain.Controls.Add(lblLocation, 0, 6);
            tableLayoutMain.Controls.Add(txtLocation, 1, 6);
            tableLayoutMain.Dock = DockStyle.Top;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.Padding = new Padding(10, 10, 30, 10);
            tableLayoutMain.RightToLeft = RightToLeft.Yes;
            tableLayoutMain.RowCount = 7;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutMain.Size = new Size(1163, 370);
            tableLayoutMain.TabIndex = 1;
            // 
            // lblModule
            // 
            lblModule.Anchor = AnchorStyles.Right;
            lblModule.AutoSize = true;
            lblModule.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            lblModule.Location = new Point(1015, 27);
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(47, 16);
            lblModule.TabIndex = 0;
            lblModule.Text = "ماژول:";
            lblModule.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbModule
            // 
            cmbModule.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbModule.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModule.Font = new Font("Tahoma", 9.5F);
            cmbModule.Location = new Point(13, 23);
            cmbModule.Name = "cmbModule";
            cmbModule.Size = new Size(996, 24);
            cmbModule.TabIndex = 1;
            // 
            // lblDayOfWeek
            // 
            lblDayOfWeek.Anchor = AnchorStyles.Right;
            lblDayOfWeek.AutoSize = true;
            lblDayOfWeek.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            lblDayOfWeek.Location = new Point(1015, 77);
            lblDayOfWeek.Name = "lblDayOfWeek";
            lblDayOfWeek.Size = new Size(66, 16);
            lblDayOfWeek.TabIndex = 2;
            lblDayOfWeek.Text = "روز هفته:";
            lblDayOfWeek.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbDayOfWeek
            // 
            cmbDayOfWeek.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbDayOfWeek.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDayOfWeek.Font = new Font("Tahoma", 9.5F);
            cmbDayOfWeek.Location = new Point(13, 73);
            cmbDayOfWeek.Name = "cmbDayOfWeek";
            cmbDayOfWeek.Size = new Size(996, 24);
            cmbDayOfWeek.TabIndex = 3;
            // 
            // lblStartTime
            // 
            lblStartTime.Anchor = AnchorStyles.Right;
            lblStartTime.AutoSize = true;
            lblStartTime.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            lblStartTime.Location = new Point(1015, 127);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(93, 16);
            lblStartTime.TabIndex = 4;
            lblStartTime.Text = "ساعت شروع:";
            lblStartTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpStartTime
            // 
            dtpStartTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpStartTime.Font = new Font("Tahoma", 9.5F);
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(13, 123);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(996, 23);
            dtpStartTime.TabIndex = 5;
            // 
            // lblEndTime
            // 
            lblEndTime.Anchor = AnchorStyles.Right;
            lblEndTime.AutoSize = true;
            lblEndTime.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            lblEndTime.Location = new Point(1015, 177);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(82, 16);
            lblEndTime.TabIndex = 6;
            lblEndTime.Text = "ساعت پایان:";
            lblEndTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpEndTime
            // 
            dtpEndTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpEndTime.Font = new Font("Tahoma", 9.5F);
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(13, 173);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(996, 23);
            dtpEndTime.TabIndex = 7;
            // 
            // lblCapacity
            // 
            lblCapacity.Anchor = AnchorStyles.Right;
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            lblCapacity.Location = new Point(1015, 227);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(88, 16);
            lblCapacity.TabIndex = 8;
            lblCapacity.Text = "ظرفیت گروه:";
            lblCapacity.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudCapacity
            // 
            nudCapacity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudCapacity.Font = new Font("Tahoma", 9.5F);
            nudCapacity.Location = new Point(13, 223);
            nudCapacity.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacity.Name = "nudCapacity";
            nudCapacity.Size = new Size(996, 23);
            nudCapacity.TabIndex = 9;
            nudCapacity.TextAlign = HorizontalAlignment.Center;
            nudCapacity.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblClassType
            // 
            lblClassType.Anchor = AnchorStyles.Right;
            lblClassType.AutoSize = true;
            lblClassType.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            lblClassType.Location = new Point(1015, 277);
            lblClassType.Name = "lblClassType";
            lblClassType.Size = new Size(70, 16);
            lblClassType.TabIndex = 10;
            lblClassType.Text = "نوع کلاس:";
            lblClassType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbClassType
            // 
            cmbClassType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbClassType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClassType.Font = new Font("Tahoma", 9.5F);
            cmbClassType.Location = new Point(13, 273);
            cmbClassType.Name = "cmbClassType";
            cmbClassType.Size = new Size(996, 24);
            cmbClassType.TabIndex = 11;
            // 
            // lblLocation
            // 
            lblLocation.Anchor = AnchorStyles.Right;
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            lblLocation.Location = new Point(1015, 327);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(115, 16);
            lblLocation.TabIndex = 12;
            lblLocation.Text = "محل/لینک کلاس:";
            lblLocation.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtLocation
            // 
            txtLocation.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtLocation.Font = new Font("Tahoma", 9.5F);
            txtLocation.Location = new Point(13, 323);
            txtLocation.Name = "txtLocation";
            txtLocation.PlaceholderText = "اتاق  یا لینک زوم";
            txtLocation.Size = new Size(996, 23);
            txtLocation.TabIndex = 13;
            txtLocation.TextAlign = HorizontalAlignment.Right;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmSeminarGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 750);
            Controls.Add(pnlMain);
            Controls.Add(toolStripMain);
            Font = new Font("Tahoma", 9.5F);
            MinimumSize = new Size(900, 600);
            Name = "FrmSeminarGroup";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "مدیریت گروه‌های سمینار";
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSeminarGroups).EndInit();
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

        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.ComboBox cmbModule;
        private System.Windows.Forms.Label lblDayOfWeek;
        private System.Windows.Forms.ComboBox cmbDayOfWeek;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.Label lblClassType;
        private System.Windows.Forms.ComboBox cmbClassType;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;

        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRegister;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dataGridViewSeminarGroups;

        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}