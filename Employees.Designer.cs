namespace DairyFarmSystem
{
    partial class Employees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employees));
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            label19 = new Label();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label13 = new Label();
            EmployeesDGV = new DataGridView();
            DOB = new DateTimePicker();
            PhoneTb = new TextBox();
            AddressTb = new TextBox();
            EmpNameTb = new TextBox();
            label9 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel1 = new Panel();
            label18 = new Label();
            pictureBox8 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            GenCb = new ComboBox();
            PassTb = new TextBox();
            label6 = new Label();
            pictureBox9 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)EmployeesDGV).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            SuspendLayout();
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Gill Sans MT", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label19.ForeColor = SystemColors.ControlDarkDark;
            label19.Location = new Point(643, 66);
            label19.Name = "label19";
            label19.Size = new Size(166, 47);
            label19.TabIndex = 65;
            label19.Text = "Employees";
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ButtonHighlight;
            button4.Font = new Font("Gill Sans MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.ControlDark;
            button4.Location = new Point(597, 313);
            button4.Name = "button4";
            button4.Size = new Size(115, 42);
            button4.TabIndex = 64;
            button4.Text = "Edit";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ButtonHighlight;
            button3.Font = new Font("Gill Sans MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.ControlDark;
            button3.Location = new Point(763, 313);
            button3.Name = "button3";
            button3.Size = new Size(115, 42);
            button3.TabIndex = 63;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.Font = new Font("Gill Sans MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ControlDark;
            button2.Location = new Point(930, 313);
            button2.Name = "button2";
            button2.Size = new Size(115, 42);
            button2.TabIndex = 62;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonHighlight;
            button1.Font = new Font("Gill Sans MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlDark;
            button1.Location = new Point(430, 313);
            button1.Name = "button1";
            button1.Size = new Size(115, 42);
            button1.TabIndex = 61;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Gill Sans MT", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = SystemColors.ControlDarkDark;
            label13.Location = new Point(665, 378);
            label13.Name = "label13";
            label13.Size = new Size(223, 47);
            label13.TabIndex = 60;
            label13.Text = "Employees List";
            label13.Click += label13_Click;
            // 
            // EmployeesDGV
            // 
            EmployeesDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EmployeesDGV.Location = new Point(265, 442);
            EmployeesDGV.Name = "EmployeesDGV";
            EmployeesDGV.RowHeadersWidth = 51;
            EmployeesDGV.RowTemplate.Height = 29;
            EmployeesDGV.Size = new Size(969, 328);
            EmployeesDGV.TabIndex = 59;
            EmployeesDGV.CellContentClick += EmployeesDGV_CellContentClick;
            // 
            // DOB
            // 
            DOB.Format = DateTimePickerFormat.Short;
            DOB.Location = new Point(657, 169);
            DOB.Name = "DOB";
            DOB.Size = new Size(125, 27);
            DOB.TabIndex = 58;
            // 
            // PhoneTb
            // 
            PhoneTb.ForeColor = SystemColors.ScrollBar;
            PhoneTb.Location = new Point(430, 259);
            PhoneTb.Name = "PhoneTb";
            PhoneTb.Size = new Size(125, 27);
            PhoneTb.TabIndex = 54;
            // 
            // AddressTb
            // 
            AddressTb.ForeColor = SystemColors.ScrollBar;
            AddressTb.Location = new Point(657, 259);
            AddressTb.Name = "AddressTb";
            AddressTb.Size = new Size(125, 27);
            AddressTb.TabIndex = 53;
            // 
            // EmpNameTb
            // 
            EmpNameTb.ForeColor = SystemColors.ScrollBar;
            EmpNameTb.Location = new Point(430, 169);
            EmpNameTb.Name = "EmpNameTb";
            EmpNameTb.Size = new Size(125, 27);
            EmpNameTb.TabIndex = 52;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Gill Sans MT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlDarkDark;
            label9.Location = new Point(645, 127);
            label9.Name = "label9";
            label9.Size = new Size(164, 39);
            label9.TabIndex = 47;
            label9.Text = "Date of birth";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Gill Sans MT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(430, 217);
            label5.Name = "label5";
            label5.Size = new Size(87, 39);
            label5.TabIndex = 46;
            label5.Text = "Phone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Gill Sans MT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(657, 217);
            label4.Name = "label4";
            label4.Size = new Size(110, 39);
            label4.TabIndex = 45;
            label4.Text = "Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Gill Sans MT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(430, 127);
            label3.Name = "label3";
            label3.Size = new Size(86, 39);
            label3.TabIndex = 44;
            label3.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gill Sans MT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(898, 129);
            label2.Name = "label2";
            label2.Size = new Size(103, 39);
            label2.TabIndex = 43;
            label2.Text = "Gender";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(label18);
            panel1.Controls.Add(pictureBox8);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 692);
            panel1.TabIndex = 41;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Gill Sans Ultra Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(75, 112);
            label18.Name = "label18";
            label18.Size = new Size(160, 42);
            label18.TabIndex = 19;
            label18.Text = "MyFarm";
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(18, 21);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(159, 106);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 16;
            pictureBox8.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlDark;
            label1.Location = new Point(445, 9);
            label1.Name = "label1";
            label1.Size = new Size(91, 33);
            label1.TabIndex = 15;
            label1.Text = "MyFarm";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(pictureBox9);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(250, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(960, 49);
            panel2.TabIndex = 42;
            // 
            // GenCb
            // 
            GenCb.FormattingEnabled = true;
            GenCb.Items.AddRange(new object[] { "Male", "Female" });
            GenCb.Location = new Point(898, 171);
            GenCb.Name = "GenCb";
            GenCb.Size = new Size(151, 28);
            GenCb.TabIndex = 66;
            // 
            // PassTb
            // 
            PassTb.ForeColor = SystemColors.ScrollBar;
            PassTb.Location = new Point(898, 259);
            PassTb.Name = "PassTb";
            PassTb.Size = new Size(125, 27);
            PassTb.TabIndex = 68;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Gill Sans MT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(898, 217);
            label6.Name = "label6";
            label6.Size = new Size(125, 39);
            label6.TabIndex = 67;
            label6.Text = "Password";
            // 
            // pictureBox9
            // 
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(908, 0);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(52, 51);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 117;
            pictureBox9.TabStop = false;
            pictureBox9.Click += pictureBox9_Click;
            // 
            // Employees
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1210, 692);
            Controls.Add(PassTb);
            Controls.Add(label6);
            Controls.Add(GenCb);
            Controls.Add(label19);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label13);
            Controls.Add(EmployeesDGV);
            Controls.Add(DOB);
            Controls.Add(PhoneTb);
            Controls.Add(AddressTb);
            Controls.Add(EmpNameTb);
            Controls.Add(label9);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Employees";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employees";
            Load += Employees_Load;
            ((System.ComponentModel.ISupportInitialize)EmployeesDGV).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private TextBox textBox1;
        private Label label20;
        private Label label19;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label13;
        private DataGridView EmployeesDGV;
        private DateTimePicker DOB;
        private TextBox PhoneTb;
        private TextBox AddressTb;
        private TextBox EmpNameTb;
        private Label label9;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panel1;
        private Label label18;
        private PictureBox pictureBox8;
        private Label label1;
        private Panel panel2;
        private ComboBox GenCb;
        private TextBox PassTb;
        private Label label6;
        private PictureBox pictureBox9;
    }
}