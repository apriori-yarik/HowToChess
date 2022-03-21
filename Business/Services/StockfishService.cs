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
        public string NextMove(string fen)
        {
            var stockfish = new Stockfish.NET.Stockfish(@"D:\stockfish_20090216_x64.exe");
            stockfish.Depth = 15;
            stockfish.SkillLevel = 30;

            stockfish.SetFenPosition(fen);

            var move = stockfish.GetBestMove();

            return move.ToString();
        }
    }
}
