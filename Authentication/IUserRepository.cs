using FileAnalyzerWinForm.Models;

namespace FileAnalyzerWinForm.Authentication
{
    public interface IUserRepository
    {
        User GetByUsername(string username);

        void Add(User user);
    }
}