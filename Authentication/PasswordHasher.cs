using System;
using System.Security.Cryptography;

namespace FileAnalyzerWinForm.Authentication
{
    public class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 600000;

        public void HashPassword(
            string password,
            out string passwordHash,
            out string salt,
            out int iterations)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required.");

            byte[] saltBytes = new byte[SaltSize];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                saltBytes,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);

                passwordHash = Convert.ToBase64String(hashBytes);
                salt = Convert.ToBase64String(saltBytes);
                iterations = Iterations;
            }
        }

        public bool VerifyPassword(
            string password,
            string passwordHash,
            string salt,
            int iterations)
        {
            if (string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(passwordHash) ||
                string.IsNullOrEmpty(salt) ||
                iterations < Iterations)
            {
                return false;
            }

            byte[] saltBytes;
            byte[] storedHash;

            try
            {
                saltBytes = Convert.FromBase64String(salt);
                storedHash = Convert.FromBase64String(passwordHash);
            }
            catch (FormatException)
            {
                return false;
            }

            if (saltBytes.Length != SaltSize ||
                storedHash.Length != HashSize)
            {
                return false;
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                saltBytes,
                iterations,
                HashAlgorithmName.SHA256))
            {
                byte[] computedHash = pbkdf2.GetBytes(HashSize);

                int difference = 0;

                for (int i = 0; i < HashSize; i++)
                {
                    difference |= computedHash[i] ^ storedHash[i];
                }

                return difference == 0;
            }
        }
    }
}
