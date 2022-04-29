using Business.Dtos.Game;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "User")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var games = await _service.GetAllAsync();

            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var game = await _service.GetAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, GameDtoWithId gameDto)
        {
            gameDto.Id = id;

            await _service.UpdateAsync(gameDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(GameDto gameDto)
        {
            await _service.CreateAsync(gameDto);

            return NoContent();
        }
    }
}
