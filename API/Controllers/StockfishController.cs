using Business.Dtos;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StockfishController : ControllerBase
    {
        private readonly IStockfishService _service;

        public StockfishController(IStockfishService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult NextMove(StockfishPositionDto position)
        {        
            string move = _service.NextMove(position.FEN);

            return Ok(move);
        }
    }
}
