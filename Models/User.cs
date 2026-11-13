namespace FileAnalyzerWinForm.Models
{
    public class User
    {
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public int HashIterations { get; set; }
    }
}
