using FileAnalyzerWinForm.Authentication;
using FileAnalyzerWinForm.View;
using System;
using System.Windows.Forms;

namespace FileAnalyzerWinForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IUserRepository repository = new TxtUserRepository();
            PasswordHasher passwordHasher = new PasswordHasher();

            AuthService authService = new AuthService(
                repository,
                passwordHasher
            );

            Application.Run(new LoginForm(authService));
        }
    }
}
