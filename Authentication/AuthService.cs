using System;
using System.IO;
using System.Text.RegularExpressions;
using FileAnalyzerWinForm.Exceptions;
using FileAnalyzerWinForm.Logging;
using FileAnalyzerWinForm.Models;

namespace FileAnalyzerWinForm.Authentication
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;
        private readonly ILogger _logger;

        public AuthService(
            IUserRepository userRepository,
            PasswordHasher passwordHasher,
            ILogger logger)
        {
            _userRepository = userRepository
                ?? throw new ArgumentNullException(nameof(userRepository));

            _passwordHasher = passwordHasher
                ?? throw new ArgumentNullException(nameof(passwordHasher));

            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
        }


        public AuthResult Register(string username, string password)
        {
            AuthResult validation = ValidateRegistration(username, password);

            if (validation != null)
            {
                return validation;
            }

            return ExceptionHandler.Execute(
                () => RegisterCore(username.Trim(), password),
                HandleError,
                IsAuthError);
        }

        public AuthResult Login(string username, string password)
        {
            AuthResult validation = ValidateCredentials(username, password);

            if (validation != null)
            {
                return validation;
            }

            return ExceptionHandler.Execute(
                () => LoginCore(username.Trim(), password),
                HandleError,
                IsAuthError);
        }

        private AuthResult RegisterCore(string username, string password)
        {
            if (_userRepository.GetByUsername(username) != null)
            {
                return AuthResult.Fail("Username already exists.");
            }

            _passwordHasher.HashPassword(
                password,
                out string passwordHash,
                out string salt,
                out int iterations
            );

            _userRepository.Add(new User
            {
                Username = username,
                PasswordHash = passwordHash,
                Salt = salt,
                HashIterations = iterations
            });

            return AuthResult.Ok("Account created successfully.");
        }

        private AuthResult LoginCore(string username, string password)
        {
            User user = _userRepository.GetByUsername(username);

            if (user == null ||
                !_passwordHasher.VerifyPassword(
                    password,
                    user.PasswordHash,
                    user.Salt,
                    user.HashIterations))
            {
                return AuthResult.Fail("Invalid username or password.");
            }

            return AuthResult.Ok("Login successful.");
        }

        private static AuthResult ValidateCredentials(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return AuthResult.Fail("Username is required.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return AuthResult.Fail("Password is required.");
            }

            return null;
        }

        private static AuthResult ValidateRegistration(string username, string password)
        {
            AuthResult result = ValidateCredentials(username, password);

            if (result != null)
            {
                return result;
            }

            if (password.Length < 8)
            {
                return AuthResult.Fail("Password must be at least 8 characters.");
            }

            string trimmed = username.Trim();

            if (trimmed.Length < 3 ||
                trimmed.Length > 30 ||
                !Regex.IsMatch(trimmed, @"^[a-zA-Z0-9_]+$"))
            {
                return AuthResult.Fail(
                    "Username must be 3-30 characters and contain only letters, numbers or underscores.");
            }

            return null;
        }

        private AuthResult HandleError(Exception ex)
        {
            switch (ex)
            {
                case InvalidOperationException _:
                    return AuthResult.Fail("Username already exists.");

                case InvalidDataException _:
                    _logger.Error("Authentication user records are corrupted.", ex);
                    return AuthResult.Fail("User records are corrupted. Please contact support.");

                case UnauthorizedAccessException _:
                    _logger.Error("Authentication file access was denied.", ex);
                    return AuthResult.Fail("Unable to access user records.");

                default:
                    _logger.Error("Authentication file access failed.", ex);
                    return AuthResult.Fail("Unable to access user records.");
            }
        }

        private static bool IsAuthError(Exception ex)
        {
            return ex is InvalidOperationException
                || ex is InvalidDataException
                || ex is IOException
                || ex is UnauthorizedAccessException;
        }
    }
}
