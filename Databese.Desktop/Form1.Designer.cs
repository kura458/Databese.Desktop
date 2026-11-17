namespace Databese.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPassword = new Button();
            btnRegister = new Button();
            txtusername = new TextBox();
            txtpassword = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            SuspendLayout();
            // 
            // btnPassword
            // 
            btnPassword.Location = new Point(395, 193);
            btnPassword.Name = "btnPassword";
            btnPassword.Size = new Size(112, 34);
            btnPassword.TabIndex = 0;
            btnPassword.Text = "Login";
            btnPassword.UseVisualStyleBackColor = true;
            btnPassword.Click += btnPassword_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(81, 298);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(112, 34);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtusername
            // 
            txtusername.Location = new Point(184, 55);
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(150, 31);
            txtusername.TabIndex = 2;
            // 
            // txtpassword
            // 
            txtpassword.Location = new Point(184, 86);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(150, 31);
            txtpassword.TabIndex = 3;
            txtpassword.UseSystemPasswordChar = true;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(77, 55);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(91, 25);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(81, 92);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 344);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtpassword);
            Controls.Add(txtusername);
            Controls.Add(btnRegister);
            Controls.Add(btnPassword);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database Desktop -Login ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private TextBox txtusername;
        private TextBox txtpassword;
        private Button btnPassword;
        private Button btnRegister;
        private Label lblUsername;
        private Label lblPassword;
    }
}
