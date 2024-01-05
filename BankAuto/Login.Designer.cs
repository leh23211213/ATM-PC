namespace ATM_PC
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUserName = new TextBox();
            btnLogin = new Button();
            guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            txtPassword = new TextBox();
            cbRole = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DodgerBlue;
            panel1.Dock = DockStyle.Left;
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(71, 450);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(150, 50);
            label1.Name = "label1";
            label1.Size = new Size(250, 24);
            label1.TabIndex = 3;
            label1.Text = "Bank Management System";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label2.Location = new Point(150, 245);
            label2.Name = "label2";
            label2.Size = new Size(96, 22);
            label2.TabIndex = 4;
            label2.Text = "UserName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label3.Location = new Point(152, 299);
            label3.Name = "label3";
            label3.Size = new Size(90, 22);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserName.Location = new Point(150, 270);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(248, 26);
            txtUserName.TabIndex = 7;
            txtUserName.TextChanged += txtPassword_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(226, 381);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(108, 38);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // guna2PictureBox2
            // 
            guna2PictureBox2.CustomizableEdges = customizableEdges1;
            guna2PictureBox2.FillColor = Color.Transparent;
            guna2PictureBox2.Image = (Image)resources.GetObject("guna2PictureBox2.Image");
            guna2PictureBox2.ImageRotate = 0F;
            guna2PictureBox2.Location = new Point(225, 99);
            guna2PictureBox2.Name = "guna2PictureBox2";
            guna2PictureBox2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox2.Size = new Size(109, 61);
            guna2PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox2.TabIndex = 9;
            guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges = customizableEdges3;
            guna2PictureBox1.FillColor = Color.Transparent;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(454, 12);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2PictureBox1.Size = new Size(28, 26);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox1.TabIndex = 10;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.Click += guna2PictureBox1_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(152, 324);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(248, 26);
            txtPassword.TabIndex = 8;
            txtPassword.TextChanged += txtUserName_TextChanged;
            // 
            // cbRole
            // 
            cbRole.Font = new Font("Times New Roman", 12F);
            cbRole.FormattingEnabled = true;
            cbRole.Items.AddRange(new object[] { "Admin", "Agent" });
            cbRole.Location = new Point(150, 204);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(250, 27);
            cbRole.TabIndex = 27;
            cbRole.Text = "Role";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(494, 450);
            Controls.Add(cbRole);
            Controls.Add(txtPassword);
            Controls.Add(guna2PictureBox1);
            Controls.Add(guna2PictureBox2);
            Controls.Add(btnLogin);
            Controls.Add(txtUserName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUserName;
        private Button btnLogin;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private TextBox txtPassword;
        private ComboBox cbRole;
    }
}