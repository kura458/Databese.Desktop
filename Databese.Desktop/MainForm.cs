
using System;
using System.Windows.Forms;

namespace Databese.Desktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Connect buttons to their click events
            btnChangePassword.Click += btnChangePassword_Click;
            btnProducts.Click += btnProducts_Click;
        }

        // Open Change Password Form
        private void btnChangePassword_Click(object? sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm =
                new ChangePasswordForm();

            changePasswordForm.ShowDialog();
        }

        // Open Product Management Form
        private void btnProducts_Click(object? sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();

            productForm.ShowDialog();
        }

        private void MainForm_Click(object? sender, EventArgs e)
        {
        }
    }
}
