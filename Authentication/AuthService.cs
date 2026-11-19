using System;
using FileAnalyzerWinForm.Models;
using FileAnalyzerWinForm.Logging;

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
            if (string.IsNullOrWhiteSpace(username))
            {
                return new AuthResult
                {
                    Success = false,
                    Message = "Username is required."
                };
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return new AuthResult
                {
                    Success = false,
                    Message = "Password is required."
                };
            }

            if (password.Length < 8)
            {
                return new AuthResult
                {
                    Success = false,
                    Message = "Password must be at least 8 characters."
                };
            }

            username = username.Trim();

            if (username.Length < 3 ||
                username.Length > 30 ||
                !System.Text.RegularExpressions.Regex.IsMatch(
                    username, @"^[a-zA-Z0-9_]+$"))
            {
                return new AuthResult
                {
                    Success = false,
                    Message = "Username must be 3-30 characters and contain only letters, numbers or underscores."
                };
            }

            try
            {
                if (_userRepository.GetByUsername(username) != null)
                {
                    return new AuthResult
                    {
                        Success = false,
                        Message = "Username already exists."
                    };
                }

                _passwordHasher.HashPassword(
                    password,
                    out string passwordHash,
                    out string salt,
                    out int iterations
                );

                var user = new User
                {
                    Username = username,
                    PasswordHash = passwordHash,
                    Salt = salt,
                    HashIterations = iterations
                };

                _userRepository.Add(user);

                return new AuthResult
                {
                    Success = true,
                    Message = "Account created successfully."
                };
            }
            catch (InvalidOperationException)
            {
                return new AuthResult
                {
                    Success = false,
                    Message = "Username already exists."
                };
            }
            catch (System.IO.InvalidDataException ex)
            {
                _logger.Error("Authentication user records are corrupted.", ex);

                return new AuthResult
                {
                    Success = false,
                    Message = "User records are corrupted. Please contact support."
                };
            }
            catch (System.IO.IOException ex)
            {
                _logger.Error("Authentication file access failed.", ex);

                return new AuthResult
                {
                    Success = false,
                    Message = "Unable to access user records."
                };
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.Error("Authentication file access was denied.", ex);

                return new AuthResult
                {
                    Success = false,
                    Message = "Unable to access user records."
                };
            }
        }


        public AuthResult Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return new AuthResult
                {
                    Success = false,
                    Message = "Username is required."
                };
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return new AuthResult
                {
                    Success = false,
                    Message = "Password is required."
                };
            }

            try
            {
                User user = _userRepository.GetByUsername(username.Trim());

                if (user == null)
                {
                    return new AuthResult
                    {
                        Success = false,
                        Message = "Invalid username or password."
                    };
                }

                bool isValid = _passwordHasher.VerifyPassword(
                    password,
                    user.PasswordHash,
                    user.Salt,
                    user.HashIterations
                );

                if (!isValid)
                {
                    return new AuthResult
                    {
                        Success = false,
                        Message = "Invalid username or password."
                    };
                }

                return new AuthResult
                {
                    Success = true,
                    Message = "Login successful."
                };
            }
            catch (System.IO.InvalidDataException ex)
            {
                _logger.Error("Authentication user records are corrupted.", ex);

                return new AuthResult
                {
                    Success = false,
                    Message = "User records are corrupted. Please contact support."
                };
            }
            catch (System.IO.IOException ex)
            {
                _logger.Error("Authentication file access failed.", ex);

                return new AuthResult
                {
                    Success = false,
                    Message = "Unable to access user records."
                };
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.Error("Authentication file access was denied.", ex);

                return new AuthResult
                {
                    Success = false,
                    Message = "Unable to access user records."
                };
            }
        }
    }
}
