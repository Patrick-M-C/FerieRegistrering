using FerieRegistreringBackend.Repository.Interfaces;
using FerieRegistreringBackend.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FerieRegistreringBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntriesController : ControllerBase
    {
        private readonly ITimeEntry _timeEntryRepository;

        public TimeEntriesController(ITimeEntry timeEntryRepository)
        {
            _timeEntryRepository = timeEntryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeEntry>>> GetAll()
        {
            return Ok(await _timeEntryRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeEntry>> GetById(int id)
        {
            var entry = await _timeEntryRepository.GetByIdAsync(id);
            if (entry == null) return NotFound();
            return Ok(entry);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<TimeEntry>>> GetByUserId(int userId)
        {
            return Ok(await _timeEntryRepository.GetByUserIdAsync(userId));
        }

        [HttpPost]
        public async Task<ActionResult<TimeEntry>> Create(TimeEntry timeEntry)
        {
            var created = await _timeEntryRepository.AddAsync(timeEntry);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TimeEntry>> Update(int id, TimeEntry timeEntry)
        {
            if (id != timeEntry.Id) return BadRequest();

            var updated = await _timeEntryRepository.UpdateAsync(timeEntry);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _timeEntryRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
