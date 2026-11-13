using System;
using System.IO;
using FileAnalyzerWinForm.Models;

namespace FileAnalyzerWinForm.Authentication
{
    public class TxtUserRepository : IUserRepository
    {
        private readonly string _filePath;

        public TxtUserRepository()
        {
            string usersDirectory = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Users"
            );

            Directory.CreateDirectory(usersDirectory);

            _filePath = Path.Combine(usersDirectory, "users.txt");

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, string.Empty);
            }
        }

        public User GetByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            foreach (string line in File.ReadLines(_filePath))
            {
                string[] parts = line.Split('|');

                if (parts.Length != 4 ||
                    !int.TryParse(parts[1], out int iterations) ||
                    iterations <= 0 ||
                    string.IsNullOrWhiteSpace(parts[0]) ||
                    string.IsNullOrWhiteSpace(parts[2]) ||
                    string.IsNullOrWhiteSpace(parts[3]))
                {
                    throw new InvalidDataException(
                        "Invalid user record format.");
                }

                if (string.Equals(
                    parts[0],
                    username.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    return new User
                    {
                        Username = parts[0],
                        HashIterations = iterations,
                        Salt = parts[2],
                        PasswordHash = parts[3]
                    };
                }
            }

            return null;
        }

        public void Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.Username) ||
                string.IsNullOrWhiteSpace(user.PasswordHash) ||
                string.IsNullOrWhiteSpace(user.Salt) ||
                user.HashIterations <= 0)
            {
                throw new ArgumentException("Invalid user data.");

                string username = user.Username.Trim();

                if (username.Contains("|") ||
                    username.Contains("\r") ||
                    username.Contains("\n"))
                {
                    throw new ArgumentException("Invalid username format.");
                }

                if (GetByUsername(username) != null)
                {
                    throw new InvalidOperationException(
                        "Username already exists.");
                }

                string line = string.Join("|",
                    username,
                    user.HashIterations,
                    user.Salt,
                    user.PasswordHash
                );

                File.AppendAllText(
                    _filePath,
                    line + Environment.NewLine
                );
            }
        }
    }
}