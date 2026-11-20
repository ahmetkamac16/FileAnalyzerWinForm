namespace FileAnalyzerWinForm.Models
{
    public class AuthResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public static AuthResult Ok(string message)
        {
            return new AuthResult { Success = true, Message = message };
        }

        public static AuthResult Fail(string message)
        {
            return new AuthResult { Success = false, Message = message };
        }
    }
}