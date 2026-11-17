namespace Databese.Desktop
{
    partial class ChangePasswordForm
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
            txtUsername = new TextBox();
            txtnewpassword = new TextBox();
            lblUsername = new Label();
            label2 = new Label();
            lblnewpassword = new Label();
            lblconfirmpassword = new Label();
            txtoldpassword = new TextBox();
            txtconfirmpassword = new TextBox();
            btnChangepassword = new Button();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(32, 43);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(150, 31);
            txtUsername.TabIndex = 0;
            // 
            // txtnewpassword
            // 
            txtnewpassword.Location = new Point(32, 186);
            txtnewpassword.Name = "txtnewpassword";
            txtnewpassword.Size = new Size(150, 31);
            txtnewpassword.TabIndex = 1;
            txtnewpassword.UseSystemPasswordChar = true;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(37, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(91, 25);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 77);
            label2.Name = "label2";
            label2.Size = new Size(121, 25);
            label2.TabIndex = 3;
            label2.Text = "Old Password";
            // 
            // lblnewpassword
            // 
            lblnewpassword.AutoSize = true;
            lblnewpassword.Location = new Point(37, 149);
            lblnewpassword.Name = "lblnewpassword";
            lblnewpassword.Size = new Size(127, 25);
            lblnewpassword.TabIndex = 4;
            lblnewpassword.Text = "New Password";
            // 
            // lblconfirmpassword
            // 
            lblconfirmpassword.AutoSize = true;
            lblconfirmpassword.Location = new Point(50, 220);
            lblconfirmpassword.Name = "lblconfirmpassword";
            lblconfirmpassword.Size = new Size(156, 25);
            lblconfirmpassword.TabIndex = 5;
            lblconfirmpassword.Text = "Confirm Password";
            // 
            // txtoldpassword
            // 
            txtoldpassword.Location = new Point(32, 115);
            txtoldpassword.Name = "txtoldpassword";
            txtoldpassword.Size = new Size(150, 31);
            txtoldpassword.TabIndex = 6;
            txtoldpassword.UseSystemPasswordChar = true;
            // 
            // txtconfirmpassword
            // 
            txtconfirmpassword.Location = new Point(32, 248);
            txtconfirmpassword.Name = "txtconfirmpassword";
            txtconfirmpassword.Size = new Size(150, 31);
            txtconfirmpassword.TabIndex = 7;
            // 
            // btnChangepassword
            // 
            btnChangepassword.Location = new Point(343, 299);
            btnChangepassword.Name = "btnChangepassword";
            btnChangepassword.Size = new Size(158, 34);
            btnChangepassword.TabIndex = 8;
            btnChangepassword.Text = "Change Pasword";
            btnChangepassword.UseVisualStyleBackColor = true;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnChangepassword);
            Controls.Add(txtconfirmpassword);
            Controls.Add(txtoldpassword);
            Controls.Add(lblconfirmpassword);
            Controls.Add(lblnewpassword);
            Controls.Add(label2);
            Controls.Add(lblUsername);
            Controls.Add(txtnewpassword);
            Controls.Add(txtUsername);
            Name = "ChangePasswordForm";
            Text = "ChangePasswordForm";
            Load += ChangePasswordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label lblUsername;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private TextBox txtUsername;
        private TextBox txtnewpassword;
        private Label lblnewpassword;
        private TextBox txtoldpassword;
        private Label lblconfirmpassword;
        private TextBox txtconfirmpassword;
        private Button btnChangepassword;
    }
}