using System;
using System.ComponentModel.DataAnnotations;

namespace FerieRegistreringBackend.Repository.Models
{
    public class LoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterRequest
    {
        public int Id { get; set; }
        
        [Required, MaxLength(120)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(120)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.Employee;
    }

    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAtUtc { get; set; }

        public string FullName { get; set; } = string.Empty; // Name + LastName samlet i service
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }

    public class MeResponse
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
