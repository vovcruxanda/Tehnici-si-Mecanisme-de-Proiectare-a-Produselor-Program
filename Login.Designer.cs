namespace DairyFarmSystem
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            UserTb = new TextBox();
            FarmTb = new TextBox();
            PassTb = new TextBox();
            button1 = new Button();
            RoleTb = new ComboBox();
            label5 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 520);
            panel1.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Gill Sans MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ControlDark;
            label8.Location = new Point(29, 335);
            label8.Name = "label8";
            label8.Size = new Size(209, 42);
            label8.TabIndex = 14;
            label8.Text = "Professionalism";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Gill Sans MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ControlDark;
            label7.Location = new Point(45, 251);
            label7.Name = "label7";
            label7.Size = new Size(183, 42);
            label7.TabIndex = 13;
            label7.Text = "Echo Friendly";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Gill Sans MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlDark;
            label6.Location = new Point(45, 163);
            label6.Name = "label6";
            label6.Size = new Size(173, 42);
            label6.TabIndex = 12;
            label6.Text = "Nice Quality";
            label6.Click += label6_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans Ultra Bold", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(391, 9);
            label1.Name = "label1";
            label1.Size = new Size(249, 61);
            label1.TabIndex = 2;
            label1.Text = "MyFarm";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(411, 62);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(199, 117);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gill Sans MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(273, 207);
            label2.Name = "label2";
            label2.Size = new Size(158, 42);
            label2.TabIndex = 4;
            label2.Text = "User Name";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Gill Sans MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(273, 249);
            label3.Name = "label3";
            label3.Size = new Size(161, 42);
            label3.TabIndex = 5;
            label3.Text = "Farm Name";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Gill Sans MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(273, 292);
            label4.Name = "label4";
            label4.Size = new Size(136, 42);
            label4.TabIndex = 6;
            label4.Text = "Password";
            label4.Click += label4_Click;
            // 
            // UserTb
            // 
            UserTb.Location = new Point(476, 220);
            UserTb.Name = "UserTb";
            UserTb.Size = new Size(209, 27);
            UserTb.TabIndex = 7;
            // 
            // FarmTb
            // 
            FarmTb.Location = new Point(476, 262);
            FarmTb.Name = "FarmTb";
            FarmTb.Size = new Size(209, 27);
            FarmTb.TabIndex = 8;
            // 
            // PassTb
            // 
            PassTb.Location = new Point(476, 305);
            PassTb.Name = "PassTb";
            PassTb.Size = new Size(209, 27);
            PassTb.TabIndex = 9;
            PassTb.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonHighlight;
            button1.Font = new Font("Gill Sans MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlDark;
            button1.Location = new Point(411, 409);
            button1.Name = "button1";
            button1.Size = new Size(170, 53);
            button1.TabIndex = 10;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // RoleTb
            // 
            RoleTb.Font = new Font("Gill Sans MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            RoleTb.FormattingEnabled = true;
            RoleTb.Items.AddRange(new object[] { "Admin", "Employee" });
            RoleTb.Location = new Point(283, 348);
            RoleTb.Name = "RoleTb";
            RoleTb.Size = new Size(233, 41);
            RoleTb.TabIndex = 0;
            RoleTb.Text = "Select Role";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Gill Sans MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(459, 465);
            label5.Name = "label5";
            label5.Size = new Size(68, 33);
            label5.TabIndex = 11;
            label5.Text = "Reset";
            label5.Click += label5_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(734, 520);
            Controls.Add(label5);
            Controls.Add(RoleTb);
            Controls.Add(button1);
            Controls.Add(PassTb);
            Controls.Add(FarmTb);
            Controls.Add(UserTb);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox UserTb;
        private TextBox FarmTb;
        private TextBox PassTb;
        private Button button1;
        private ComboBox RoleTb;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label7;
    }
}