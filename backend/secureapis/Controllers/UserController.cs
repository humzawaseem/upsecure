using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using secureapis.Models;

namespace secureapis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
      
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _repository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _repository = userRepository;
        }

   
        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] User user)
        {
            await _repository.CreateAsync(user);
            return Ok(user);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var user = await _repository.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] User user)
        {
            await _repository.UpdateAsync(id, user);
            return Ok();
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }

    }
}
