using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FerieRegistreringBackend.Repository.Interfaces;
using FerieRegistreringBackend.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;


namespace FerieRegistreringBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authRepository;

        public AuthController(IAuth authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request)
        {
            var result = await _authRepository.LoginAsync(request);
            if (result == null) return Unauthorized("Ugyldige login-oplysninger.");
            return Ok(result);
        }

        [HttpPost("register")]
        [Authorize(Roles = nameof(UserRole.Leader))]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
        {
            var actingUser = new User
            {
                Id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
                Name = User.Identity?.Name ?? "",
                Email = User.FindFirstValue(ClaimTypes.Email) ?? "",
                Role = User.IsInRole(nameof(UserRole.Leader)) ? UserRole.Leader : UserRole.Employee
            };

            var result = await _authRepository.RegisterAsync(request, actingUser);
            return Ok(result);
        }
    }
}
