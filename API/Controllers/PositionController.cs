using Business.Dtos.Position;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _service;

        public PositionController(IPositionService service)
        {
            _service = service;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var positions = await _service.GetAllAsync();

            return Ok(positions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var position = await _service.GetAsync(id);

            if (position == null)
            {
                return NotFound();
            }

            return Ok(position);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, PositionDtoWithId positionDto)
        {
            positionDto.Id = id;

            await _service.UpdateAsync(positionDto);

            return NoContent();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(PositionDto positionDto)
        {
            await _service.CreateAsync(positionDto);

            return NoContent();
        }
    }
}
