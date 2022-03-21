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
        public IActionResult NextMove([FromBody] string fen)
        {        
            string move = _service.NextMove(fen);

            return Ok(move);
        }
    }
}
