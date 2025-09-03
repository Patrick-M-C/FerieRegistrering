using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FerieRegistreringBackend.Repository.Interfaces;
using FerieRegistreringBackend.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FerieRegistreringBackend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeam _teams;
        public TeamsController(ITeam teams) { _teams = teams; }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Leader))]
        public async Task<ActionResult<TeamResponseDto>> Create([FromBody] TeamCreateDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var t = await _teams.CreateAsync(new Team
            {
                Name = dto.Name,
                Description = dto.Description,
                LeaderUserId = dto.LeaderUserId
            });

            return Ok(new TeamResponseDto
            {
                TeamId = t.TeamId,
                Name = t.Name,
                Description = t.Description,
                IsActive = t.IsActive,
                LeaderUserId = t.LeaderUserId,
                CreatedAtUtc = t.CreatedAtUtc
            });
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRole.Leader))]
        public async Task<IActionResult> GetAll([FromQuery] bool includeInactive = false)
        {
            var list = await _teams.GetAllAsync(includeInactive);
            var res = list.Select(t => new TeamResponseDto
            {
                TeamId = t.TeamId,
                Name = t.Name,
                Description = t.Description,
                IsActive = t.IsActive,
                LeaderUserId = t.LeaderUserId,
                CreatedAtUtc = t.CreatedAtUtc
            });
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var t = await _teams.GetByIdAsync(id, includeMembers: true);
            if (t == null) return NotFound();
            return Ok(new TeamResponseDto
            {
                TeamId = t.TeamId,
                Name = t.Name,
                Description = t.Description,
                IsActive = t.IsActive,
                LeaderUserId = t.LeaderUserId,
                CreatedAtUtc = t.CreatedAtUtc,
                Members = t.Members.Select(m => new { m.Id, m.Name, m.LastName, m.Email })
            });
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> MyTeam()
        {
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                      ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(sub, out var userId)) return Unauthorized();

            var t = await _teams.GetMyTeamAsync(userId);
            if (t == null) return Ok(null);
            return Ok(new TeamResponseDto
            {
                TeamId = t.TeamId,
                Name = t.Name,
                Description = t.Description,
                IsActive = t.IsActive,
                LeaderUserId = t.LeaderUserId,
                CreatedAtUtc = t.CreatedAtUtc,
                Members = t.Members.Select(m => new { m.Id, m.Name, m.LastName, m.Email })
            });
        }

        [HttpPut]
        [Authorize(Roles = nameof(UserRole.Leader))]
        public async Task<IActionResult> Update([FromBody] TeamUpdateDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var t = await _teams.UpdateAsync(new Team
            {
                TeamId = dto.TeamId,
                Name = dto.Name,
                Description = dto.Description,
                LeaderUserId = dto.LeaderUserId
            });
            if (t == null) return NotFound();
            return Ok(new { message = "Updated" });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = nameof(UserRole.Leader))]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var ok = await _teams.SoftDeleteAsync(id);
            return ok ? Ok(new { message = "Deactivated" }) : NotFound();
        }

        [HttpPut("{id:int}/members/{userId:int}")]
        [Authorize(Roles = nameof(UserRole.Leader))]
        public async Task<IActionResult> AddMember(int id, int userId)
        {
            var ok = await _teams.AddMemberAsync(id, userId);
            return ok ? Ok(new { message = "Member added" }) : NotFound();
        }

        [HttpDelete("{id:int}/members/{userId:int}")]
        [Authorize(Roles = nameof(UserRole.Leader))]
        public async Task<IActionResult> RemoveMember(int id, int userId)
        {
            var ok = await _teams.RemoveMemberAsync(id, userId);
            return ok ? Ok(new { message = "Member removed" }) : NotFound();
        }
    }
}