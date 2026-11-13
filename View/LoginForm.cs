using System;
using System.Windows.Forms;
using FileAnalyzerWinForm.Authentication;
using FileAnalyzerWinForm.Models;

namespace FileAnalyzerWinForm.View
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        public LoginForm(AuthService authService)
        {
            InitializeComponent();

            _authService = authService
                ?? throw new ArgumentNullException(nameof(authService));
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            pnlLogin.Visible = true;
            pnlRegister.Visible = false;

            pnlLogin.BringToFront();
        }

        private void lnkRegister_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            pnlLogin.Visible = false;
            pnlRegister.Visible = true;

            pnlRegister.BringToFront();
        }

        private void lnkBackToLogin_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            pnlRegister.Visible = false;
            pnlLogin.Visible = true;

            pnlLogin.BringToFront();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegisterUsername.Text;
            string password = txtRegisterPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Passwords do not match.",
                    "Registration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            AuthResult result = _authService.Register(username, password);

            if (!result.Success)
            {
                MessageBox.Show(
                    result.Message,
                    "Registration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MessageBox.Show(
                result.Message,
                "Registration Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            txtRegisterUsername.Clear();
            txtRegisterPassword.Clear();
            txtConfirmPassword.Clear();

            pnlRegister.Visible = false;
            pnlLogin.Visible = true;
            pnlLogin.BringToFront();
        }
    }
}
