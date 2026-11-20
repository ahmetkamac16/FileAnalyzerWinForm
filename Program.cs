using FileAnalyzerWinForm.Authentication;
using FileAnalyzerWinForm.View;
using System;
using System.Windows.Forms;
using FileAnalyzerWinForm.Logging;
using System.Globalization;

namespace FileAnalyzerWinForm
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IUserRepository repository = new TxtUserRepository();
            PasswordHasher passwordHasher = new PasswordHasher();
            ILogger logger = new FileLogger();

            AuthService authService = new AuthService(
                repository,
                passwordHasher,
                logger
            );

            Application.Run(new LoginForm(authService));
        }
    }
}
