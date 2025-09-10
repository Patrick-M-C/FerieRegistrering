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
    public class LeavesController : ControllerBase
    {
        private readonly IVacation _vacations;
        public LeavesController(IVacation vacations) => _vacations = vacations;

        // Employee: opret anmodning
        [HttpPost("request")]
        [Authorize]
        public async Task<ActionResult<VacationResponseDto>> Request([FromBody] VacationRequestDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            if (dto.EndDate < dto.StartDate) return BadRequest("EndDate must be >= StartDate.");

            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                   ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(sub, out var userId)) return Unauthorized();

            var created = await _vacations.CreateAsync(userId, new Vacation
            {
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Reason = dto.Reason ?? string.Empty
            });

            return Ok(new VacationResponseDto
            {
                Id = created.Id,
                StartDate = created.StartDate,
                EndDate = created.EndDate,
                Reason = created.Reason,
                Status = created.Status,
                IsApproved = created.IsApproved,
                EmployeeName = created.User is null ? string.Empty : $"{created.User.Name} {created.User.LastName}",
                UserId = created.UserId,
                CreatedAtUtc = created.CreatedAtUtc
            });
        }

        // Employee: se egne anmodninger
        [HttpGet("mine")]
        [Authorize]
        public async Task<ActionResult> Mine()
        {
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                   ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(sub, out var userId)) return Unauthorized();

            var list = await _vacations.GetMineAsync(userId);
            var res = list.Select(x => new VacationResponseDto
            {
                Id = x.Id,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Reason = x.Reason,
                Status = x.Status,
                IsApproved = x.IsApproved,
                EmployeeName = x.User is null ? string.Empty : $"{x.User.Name} {x.User.LastName}",
                UserId = x.UserId,
                CreatedAtUtc = x.CreatedAtUtc,
                DecidedAtUtc = x.DecidedAtUtc,
                ManagerComment = x.ManagerComment
            });
            return Ok(res);
        }

        // Leader: se ventende anmodninger
        [HttpGet("pending")]
        [Authorize(Roles = nameof(UserRole.Leader))]
        public async Task<ActionResult> Pending()
        {
            var list = await _vacations.GetPendingAsync();
            var res = list.Select(x => new VacationResponseDto
            {
                Id = x.Id,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Reason = x.Reason,
                Status = x.Status,
                IsApproved = x.IsApproved,
                EmployeeName = x.User is null ? string.Empty : $"{x.User.Name} {x.User.LastName}",
                UserId = x.UserId,
                CreatedAtUtc = x.CreatedAtUtc
            });
            return Ok(res);
        }

        // Leader: godkend
        [HttpPut("approve/{id:int}")]
        [Authorize(Roles = nameof(UserRole.Leader))]
        public async Task<ActionResult<VacationResponseDto>> Approve(int id, [FromBody] VacationDecisionDto dto)
        {
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                   ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(sub, out var leaderId)) return Unauthorized();

            var v = await _vacations.ApproveAsync(id, leaderId, dto.ManagerComment);
            if (v is null) return NotFound();

            return Ok(new VacationResponseDto
            {
                Id = v.Id,
                StartDate = v.StartDate,
                EndDate = v.EndDate,
                Reason = v.Reason,
                Status = v.Status,
                IsApproved = v.IsApproved,
                EmployeeName = v.User is null ? string.Empty : $"{v.User.Name} {v.User.LastName}",
                UserId = v.UserId,
                CreatedAtUtc = v.CreatedAtUtc,
                DecidedAtUtc = v.DecidedAtUtc,
                ManagerComment = v.ManagerComment
            });
        }

        // Leader: afvis
        [HttpPut("reject/{id:int}")]
        [Authorize(Roles = nameof(UserRole.Leader))]
        public async Task<ActionResult<VacationResponseDto>> Reject(int id, [FromBody] VacationDecisionDto dto)
        {
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                   ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(sub, out var leaderId)) return Unauthorized();

            var v = await _vacations.RejectAsync(id, leaderId, dto.ManagerComment);
            if (v is null) return NotFound();

            return Ok(new VacationResponseDto
            {
                Id = v.Id,
                StartDate = v.StartDate,
                EndDate = v.EndDate,
                Reason = v.Reason,
                Status = v.Status,
                IsApproved = v.IsApproved,
                EmployeeName = v.User is null ? string.Empty : $"{v.User.Name} {v.User.LastName}",
                UserId = v.UserId,
                CreatedAtUtc = v.CreatedAtUtc,
                DecidedAtUtc = v.DecidedAtUtc,
                ManagerComment = v.ManagerComment
            });
        }
    }
}