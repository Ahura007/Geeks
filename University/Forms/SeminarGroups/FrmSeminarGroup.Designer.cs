namespace University.Forms.SeminarGroups
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            button1 = new Button();
            label2 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox3 = new TextBox();
            ComClassType = new ComboBox();
            textBox1 = new TextBox();
            ComLesson = new ComboBox();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(ComClassType);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(ComLesson);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(959, 125);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "ثبت  درس جدید";
            // 
            // button1
            // 
            button1.Location = new Point(12, 80);
            button1.Name = "button1";
            button1.Size = new Size(931, 29);
            button1.TabIndex = 1;
            button1.Text = "ثبت کلاس جدید";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 54);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 10;
            label2.Text = "پایان کلاس";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "yyyy/MM/dd HH:mm";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(12, 51);
            dateTimePicker2.MinDate = new DateTime(2025, 12, 31, 8, 21, 26, 335);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.Size = new Size(121, 23);
            dateTimePicker2.TabIndex = 9;
            dateTimePicker2.Value = new DateTime(2025, 12, 31, 8, 21, 26, 335);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 25);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 8;
            label1.Text = "شروع کلاس";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy/MM/dd HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(12, 22);
            dateTimePicker1.MinDate = new DateTime(2025, 12, 31, 8, 21, 26, 335);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(121, 23);
            dateTimePicker1.TabIndex = 7;
            dateTimePicker1.Value = new DateTime(2025, 12, 31, 8, 21, 26, 335);
            // 
            // textBox3
            // 
            textBox3.Location = new Point(578, 22);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "ظرفیت کلاس";
            textBox3.Size = new Size(179, 23);
            textBox3.TabIndex = 6;
            // 
            // ComClassType
            // 
            ComClassType.DropDownStyle = ComboBoxStyle.DropDownList;
            ComClassType.FormattingEnabled = true;
            ComClassType.Location = new Point(208, 22);
            ComClassType.Name = "ComClassType";
            ComClassType.Size = new Size(365, 23);
            ComClassType.TabIndex = 5;
            ComClassType.SelectedIndexChanged += ComClassType_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(208, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(365, 23);
            textBox1.TabIndex = 4;
            // 
            // ComLesson
            // 
            ComLesson.DropDownStyle = ComboBoxStyle.DropDownList;
            ComLesson.FormattingEnabled = true;
            ComLesson.Location = new Point(763, 22);
            ComLesson.Name = "ComLesson";
            ComLesson.Size = new Size(180, 23);
            ComLesson.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Dock = DockStyle.Bottom;
            groupBox2.Location = new Point(0, 131);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(959, 319);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "لیست کلاس";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 19);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(953, 297);
            dataGridView1.TabIndex = 0;
            // 
            // FrmSeminarGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 450);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FrmSeminarGroup";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmSeminarGroup";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private ComboBox ComClassType;
        private TextBox textBox1;
        private ComboBox ComLesson;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker2;
    }
}