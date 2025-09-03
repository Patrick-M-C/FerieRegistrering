using FerieRegistreringBackend.Repository.Interfaces;
using FerieRegistreringBackend.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FerieRegistreringBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userRepository;

        public UserController(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return Ok(await _userRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            var created = await _userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(int id, User user)
        {
            if (id != user.Id) return BadRequest();

            var updated = await _userRepository.UpdateAsync(user);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _userRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
