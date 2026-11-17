
using System;
using System.Windows.Forms;
using Databese.Desktop.Services;

namespace Databese.Desktop
{
    public partial class ChangePasswordForm : Form
    {
        private readonly ApiClient _apiClient = new ApiClient();

        public ChangePasswordForm()
        {
            InitializeComponent();

            // Connect button click event
            btnChangepassword.Click += btnChangepassword_Click;
        }

        // Form loading event
        private void ChangePasswordForm_Load(object? sender, EventArgs e)
        {
            // Form loading event
        }

        // Change Password button click event
        private async void btnChangepassword_Click(
            object? sender, EventArgs e)
        {
            try
            {
                // 1. Get values from textboxes
                string username = txtUsername.Text.Trim();
                string oldPassword = txtoldpassword.Text;
                string newPassword = txtnewpassword.Text;
                string confirmPassword = txtconfirmpassword.Text;

                // 2. Check empty fields
                if (string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(oldPassword) ||
                    string.IsNullOrWhiteSpace(newPassword) ||
                    string.IsNullOrWhiteSpace(confirmPassword))
                {
                    MessageBox.Show(
                        "Please fill in all fields.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // 3. Check new password length
                if (newPassword.Length < 8)
                {
                    MessageBox.Show(
                        "New password must contain at least 8 characters.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // 4. Check password confirmation
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show(
                        "New password and confirmation do not match.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // 5. Call API to change password
                var result = await _apiClient.ChangePasswordAsync(
                    username,
                    oldPassword,
                    newPassword);

                // 6. Display API response
                if (result != null && result.Success)
                {
                    MessageBox.Show(
                        result.Message,
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Clear password fields after success
                    txtoldpassword.Clear();
                    txtnewpassword.Clear();
                    txtconfirmpassword.Clear();
                }
                else
                {
                    MessageBox.Show(
                        result?.Message ?? "Password change failed.",
                        "Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "API Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
