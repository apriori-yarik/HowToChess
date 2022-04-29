using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(HowToChessDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Game> OnBeforeGetAll()
        {
            return Items.Include(x => x.User).AsNoTracking();
        }
    }
}
