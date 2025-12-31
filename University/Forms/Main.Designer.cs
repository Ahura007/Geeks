namespace University.Forms;
 
    partial class Main
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
        BtnStudent = new Button();
        BtnLesson = new Button();
        BtnClass = new Button();
        SuspendLayout();
        // 
        // BtnStudent
        // 
        BtnStudent.Location = new Point(12, 12);
        BtnStudent.Name = "BtnStudent";
        BtnStudent.Size = new Size(170, 59);
        BtnStudent.TabIndex = 0;
        BtnStudent.Text = "مدیریت دانش آموزان";
        BtnStudent.UseVisualStyleBackColor = true;
        BtnStudent.Click += BtnStudent_Click;
        // 
        // BtnLesson
        // 
        BtnLesson.Location = new Point(188, 12);
        BtnLesson.Name = "BtnLesson";
        BtnLesson.Size = new Size(170, 59);
        BtnLesson.TabIndex = 1;
        BtnLesson.Text = "مدیریت درس";
        BtnLesson.UseVisualStyleBackColor = true;
        BtnLesson.Click += BtnLesson_Click;
        // 
        // BtnClass
        // 
        BtnClass.Location = new Point(364, 12);
        BtnClass.Name = "BtnClass";
        BtnClass.Size = new Size(170, 59);
        BtnClass.TabIndex = 2;
        BtnClass.Text = "مدیریت کلاس";
        BtnClass.UseVisualStyleBackColor = true;
        BtnClass.Click += BtnClass_Click;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(544, 450);
        Controls.Add(BtnClass);
        Controls.Add(BtnLesson);
        Controls.Add(BtnStudent);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        Name = "Main";
        RightToLeft = RightToLeft.Yes;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Main";
        ResumeLayout(false);
    }

    #endregion

    private Button BtnStudent;
    private Button BtnLesson;
    private Button BtnClass;
}
 