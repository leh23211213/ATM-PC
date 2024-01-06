namespace ATM_PC
{
    partial class Settings
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox4).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(guna2PictureBox2);
            panel1.Dock = DockStyle.Left;
            panel1.ForeColor = Color.Transparent;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(84, 497);
            panel1.TabIndex = 20;
            // 
            // guna2PictureBox2
            // 
            guna2PictureBox2.CustomizableEdges = customizableEdges1;
            guna2PictureBox2.FillColor = Color.Transparent;
            guna2PictureBox2.Image = (Image)resources.GetObject("guna2PictureBox2.Image");
            guna2PictureBox2.ImageRotate = 0F;
            guna2PictureBox2.InitialImage = (Image)resources.GetObject("guna2PictureBox2.InitialImage");
            guna2PictureBox2.Location = new Point(0, 0);
            guna2PictureBox2.Margin = new Padding(4);
            guna2PictureBox2.Name = "guna2PictureBox2";
            guna2PictureBox2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox2.Size = new Size(84, 81);
            guna2PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox2.TabIndex = 20;
            guna2PictureBox2.TabStop = false;
            guna2PictureBox2.Click += guna2PictureBox2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label4.Location = new Point(296, 29);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(75, 22);
            label4.TabIndex = 21;
            label4.Text = "Settings";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(138, 132);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(180, 26);
            textBox1.TabIndex = 23;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(138, 251);
            textBox2.Margin = new Padding(4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(180, 26);
            textBox2.TabIndex = 25;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label1.Location = new Point(138, 220);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(107, 22);
            label1.TabIndex = 24;
            label1.Text = "Bank Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label3.Location = new Point(138, 335);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(66, 22);
            label3.TabIndex = 26;
            label3.Text = "Theme";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Male", "Female" });
            comboBox1.Location = new Point(138, 365);
            comboBox1.Margin = new Padding(4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(180, 29);
            comboBox1.TabIndex = 27;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label2.Location = new Point(138, 101);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(184, 22);
            label2.TabIndex = 28;
            label2.Text = "Admin new password";
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            button1.Location = new Point(372, 126);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(122, 46);
            button1.TabIndex = 29;
            button1.Text = "Apply";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            button2.Location = new Point(372, 245);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(122, 46);
            button2.TabIndex = 30;
            button2.Text = "Apply";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            button3.Location = new Point(372, 356);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(122, 46);
            button3.TabIndex = 31;
            button3.Text = "Apply";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // guna2PictureBox5
            // 
            guna2PictureBox5.CustomizableEdges = customizableEdges3;
            guna2PictureBox5.FillColor = Color.Transparent;
            guna2PictureBox5.Image = (Image)resources.GetObject("guna2PictureBox5.Image");
            guna2PictureBox5.ImageRotate = 0F;
            guna2PictureBox5.Location = new Point(556, 12);
            guna2PictureBox5.Name = "guna2PictureBox5";
            guna2PictureBox5.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2PictureBox5.Size = new Size(28, 26);
            guna2PictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox5.TabIndex = 41;
            guna2PictureBox5.TabStop = false;
            guna2PictureBox5.Click += guna2PictureBox5_Click;
            // 
            // guna2PictureBox4
            // 
            guna2PictureBox4.CustomizableEdges = customizableEdges5;
            guna2PictureBox4.FillColor = Color.Transparent;
            guna2PictureBox4.Image = (Image)resources.GetObject("guna2PictureBox4.Image");
            guna2PictureBox4.ImageRotate = 0F;
            guna2PictureBox4.Location = new Point(590, 12);
            guna2PictureBox4.Name = "guna2PictureBox4";
            guna2PictureBox4.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2PictureBox4.Size = new Size(28, 26);
            guna2PictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox4.TabIndex = 40;
            guna2PictureBox4.TabStop = false;
            guna2PictureBox4.Click += guna2PictureBox4_Click_1;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(630, 497);
            Controls.Add(guna2PictureBox5);
            Controls.Add(guna2PictureBox4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "Settings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label3;
        private ComboBox comboBox1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
    }
}