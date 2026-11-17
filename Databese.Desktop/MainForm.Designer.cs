namespace Databese.Desktop
{
    partial class MainForm
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
            btnChangePassword = new Button();
            btnProducts = new Button();
            SuspendLayout();
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(282, 269);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(176, 34);
            btnChangePassword.TabIndex = 0;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // btnProducts
            // 
            btnProducts.Location = new Point(110, 137);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(213, 34);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Product Management";
            btnProducts.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnProducts);
            Controls.Add(btnChangePassword);
            Name = "MainForm";
            Text = "MainForm";
            Click += MainForm_Click;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button btnChangePassword;
        private Button btnProducts;
    }
}