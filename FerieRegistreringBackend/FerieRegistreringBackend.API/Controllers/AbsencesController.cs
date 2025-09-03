using System;
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
    public class AbsencesController : ControllerBase
    {
        private readonly IAbsence _absences;
        public AbsencesController(IAbsence absences) { _absences = absences; }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<AbsenceResponseDto>> Create([FromBody] AbsenceCreateDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(sub, out var userId)) return Unauthorized();

            var created = await _absences.CreateAsync(userId, new Absence
            {
                Type = dto.Type,
                Date = dto.Date,
                Note = dto.Note
            });

            return Ok(new AbsenceResponseDto
            {
                Id = created.Id,
                UserId = created.UserId,
                EmployeeName = created.User is null ? string.Empty : $"{created.User.Name} {created.User.LastName}",
                Type = created.Type,
                Date = created.Date,
                Note = created.Note,
                CreatedAtUtc = created.CreatedAtUtc
            });
        }

        [HttpGet("mine")]
        [Authorize]
        public async Task<IActionResult> Mine([FromQuery] DateOnly? from = null, [FromQuery] DateOnly? to = null)
        {
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(sub, out var userId)) return Unauthorized();

            var list = await _absences.GetMineAsync(userId, from, to);
            var res = list.Select(a => new AbsenceResponseDto
            {
                Id = a.Id,
                UserId = a.UserId,
                EmployeeName = a.User is null ? string.Empty : $"{a.User.Name} {a.User.LastName}",
                Type = a.Type,
                Date = a.Date,
                Note = a.Note,
                CreatedAtUtc = a.CreatedAtUtc
            });
            return Ok(res);
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRole.Leader))]
        public async Task<IActionResult> GetAll([FromQuery] DateOnly? from = null, [FromQuery] DateOnly? to = null, [FromQuery] int? userId = null)
        {
            var list = await _absences.GetAllAsync(from, to, userId);
            var res = list.Select(a => new AbsenceResponseDto
            {
                Id = a.Id,
                UserId = a.UserId,
                EmployeeName = a.User is null ? string.Empty : $"{a.User.Name} {a.User.LastName}",
                Type = a.Type,
                Date = a.Date,
                Note = a.Note,
                CreatedAtUtc = a.CreatedAtUtc
            });
            return Ok(res);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(sub, out var actingUserId)) return Unauthorized();
            var isLeader = User.IsInRole(nameof(UserRole.Leader));

            var ok = await _absences.DeleteAsync(id, actingUserId, isLeader);
            return ok ? Ok(new { message = "Deleted" }) : NotFound();
        }
    }
}