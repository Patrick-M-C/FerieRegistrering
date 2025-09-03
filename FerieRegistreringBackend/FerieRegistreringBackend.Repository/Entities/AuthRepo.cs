using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FerieRegistreringBackend.Repository.Database;
using FerieRegistreringBackend.Repository.Interfaces;
using FerieRegistreringBackend.Repository.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FerieRegistreringBackend.Repository.Entities
{
    public class AuthRepo : IAuth
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _cfg;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthRepo(DatabaseContext context, IConfiguration cfg)
        {
            _context = context;
            _cfg = cfg;
        }

        
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.IsActive);
        }

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest request)
        {
            var user = await GetByEmailAsync(request.Email);
            if (user == null) return null;

            var result = _hasher.VerifyHashedPassword(user, user.Password, request.Password);
            if (result == PasswordVerificationResult.Failed) return null;

            return GenerateToken(user);
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request, User? actingUser = null)
        {
            if (await EmailExistsAsync(request.Email))
                throw new InvalidOperationException("Email er allerede registreret.");

            var user = new User
            {
                Id = 0,
                Name = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Role = request.Role,
                Password = "" // sættes nedenfor
            };

            user.Password = _hasher.HashPassword(user, request.Password);

            await AddAsync(user);

            return GenerateToken(user);
        }

        // jwt handler
        private AuthResponse GenerateToken(User user)
        {
            var issuer = _cfg["Jwt:Issuer"];
            var audience = _cfg["Jwt:Audience"];
            var keyStr = _cfg["Jwt:Key"];
            if (string.IsNullOrWhiteSpace(issuer) || string.IsNullOrWhiteSpace(audience) || string.IsNullOrWhiteSpace(keyStr))
                throw new InvalidOperationException("JWT-konfiguration mangler. Tjek appsettings for Jwt:Issuer, Jwt:Audience og Jwt:Key.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.Name} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddHours(8);

            var token = new JwtSecurityToken(issuer, audience, claims, expires: expires, signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResponse
            {
                Token = jwt,
                ExpiresAtUtc = expires,
                FullName = $"{user.Name} {user.LastName}",
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}