using System;
using System.Windows.Forms;

namespace FileAnalyzerWinForm.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
