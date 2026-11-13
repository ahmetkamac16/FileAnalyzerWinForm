using System;
using System.Windows.Forms;
using FileAnalyzerWinForm.Authentication;

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
    }
}
