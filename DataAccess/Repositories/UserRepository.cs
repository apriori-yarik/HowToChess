using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
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
    }
}
