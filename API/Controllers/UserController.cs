using Business.Dtos.User;
using Business.Dtos.UserPosition;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize(Policy = "User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        
        [Authorize(Policy = "Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _service.GetAllAsync();

            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var id = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);

            var user = await _service.GetAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UserDtoWithIdWithoutRole user)
        {
            var id = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);
            user.Id = id;

            await _service.UpdateAsync(user);

            return NoContent();
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync()
        {
            var id = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);
            await _service.DeleteAsync(id);

            return NoContent();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut]
        [Route("position")]
        public async Task<IActionResult> AddPositionAsync(UserPositionPositionIdDto dto)
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);

            var user = await _service.GetAsync(userId);
            dto.UserId = user.Id;

            await _service.AddPositionAsync(user, dto);

            return NoContent();
        }
    }
}
