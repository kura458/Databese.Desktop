
using System;
using System.Windows.Forms;
using Databese.Desktop.Services;

namespace Databese.Desktop
{
    public partial class Form1 : Form
    {
        private readonly ApiClient _apiClient = new ApiClient();

        public Form1()
        {
            InitializeComponent();
        }

        // LOGIN BUTTON
        private async void btnPassword_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtusername.Text.Trim();
                string password = txtpassword.Text;

                if (string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter username and password.");
                    return;
                }

                var result = await _apiClient.LoginAsync(username, password);

                if (result != null && result.Success)
                {
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message);
            }
        }

        // REGISTER BUTTON
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtusername.Text.Trim();
                string password = txtpassword.Text;

                if (string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter username and password.");
                    return;
                }

                var result = await _apiClient.RegisterAsync(username, password);

                if (result != null)
                {
                    MessageBox.Show(result.Message, "Registration Result");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration error: " + ex.Message);
            }
        }
    }
}
