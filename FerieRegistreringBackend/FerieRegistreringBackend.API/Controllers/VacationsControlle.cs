using FerieRegistreringBackend.Repository.Interfaces;
using FerieRegistreringBackend.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FerieRegistreringBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private readonly IVacation _vacationRepository;

        public VacationsController(IVacation vacationRepository)
        {
            _vacationRepository = vacationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacation>>> GetAll()
        {
            return Ok(await _vacationRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vacation>> GetById(int id)
        {
            var vacation = await _vacationRepository.GetByIdAsync(id);
            if (vacation == null) return NotFound();
            return Ok(vacation);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Vacation>>> GetByUserId(int userId)
        {
            var vacations = await _vacationRepository.GetByUserIdAsync(userId);
            return Ok(vacations);
        }

        [HttpPost]
        public async Task<ActionResult<Vacation>> Create(Vacation vacation)
        {
            var created = await _vacationRepository.AddAsync(vacation);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Vacation>> Update(int id, Vacation vacation)
        {
            if (id != vacation.Id) return BadRequest();

            var updated = await _vacationRepository.UpdateAsync(vacation);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _vacationRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
