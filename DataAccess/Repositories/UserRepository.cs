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
    public class UserRepository : BaseRepository<User>, IUserRepository 
    {
        public UserRepository(HowToChessDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<User> OnBeforeGetAll()
        {
            return Items.Include(x => x.Role).Include(x => x.UserPositions).AsNoTracking();
        }
    }
}
