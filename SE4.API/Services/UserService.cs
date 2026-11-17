using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SE4.API.DTOs;
using SE4.API.Interfaces;
using SE4.data.Context;
using SE4.data.Entities;

namespace SE4.API.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(
            AppDbContext context,
            IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            string username = dto.Username.Trim();

            // Check if username already exists
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (existingUser != null)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Username already exists"
                };
            }

            // Create new user
            var user = new User
            {
                Username = username,
                CreatedAt = DateTime.UtcNow
            };

            // Hash password using the actual user object
            user.PasswordHash = _passwordHasher.HashPassword(
                user, dto.Password);

            // Save user
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Success = true,
                Message = "User registered successfully"
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            string username = dto.Username.Trim();

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            var result = _passwordHasher.VerifyHashedPassword(
                user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            return new AuthResponseDto
            {
                Success = true,
                Message = "Login successful"
            };
        }

        public async Task<AuthResponseDto> ChangePasswordAsync(ChangePasswordDto dto)
        {
            string username = dto.Username.Trim();

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null || _passwordHasher.VerifyHashedPassword(
                    user, user.PasswordHash, dto.OldPassword) == PasswordVerificationResult.Failed)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.NewPassword);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Success = true,
                Message = "Password changed successfully"
            };
        }
    }
}
