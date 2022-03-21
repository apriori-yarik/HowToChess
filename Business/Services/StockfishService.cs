using Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class StockfishService : IStockfishService
    {
        private readonly Stockfish.NET.Stockfish _stockfish;

        public StockfishService(Stockfish.NET.Stockfish stockfish)
        {
            _stockfish = stockfish;
        }

        public string NextMove(string fen)
        {
            _stockfish.Depth = 15;
            _stockfish.SkillLevel = 100;

            _stockfish.SetFenPosition(fen);

            var move = _stockfish.GetBestMove();

            return move.ToString();
        }
    }
}
