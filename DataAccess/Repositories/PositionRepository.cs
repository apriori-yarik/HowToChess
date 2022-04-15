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
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(HowToChessDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Position> OnBeforeGetAll()
        {
            return Items.Include(x => x.UserPositions).AsNoTracking();
        }
    }
}
