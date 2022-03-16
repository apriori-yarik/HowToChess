using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BaseRepository<Entity> : IBaseRepository
        where Entity : BaseEntity
    {
        protected HowToChessDbContext DbContext { get; }
        protected DbSet<Entity> Items { get; }

        protected IMapper Mapper { get; }

        public BaseRepository(HowToChessDbContext context, IMapper mapper)
        {
            DbContext = context;
            Items = DbContext.Set<Entity>();
            Mapper = mapper;
        }

        public async Task<Dto> GetByIdAsync<Dto>(Guid id)
            => Mapper.Map<Dto>(await Items.FirstOrDefaultAsync(x => x.Id == id));

        public async Task<List<Dto>> GetAllAsync<Dto>(Expression<Func<Dto, bool>> filter = null)
        {
            var query = Items.AsQueryable();

            if (filter != null)
                query = query.Where(Mapper.Map<Expression<Func<Entity, bool>>>(filter));

            return await Mapper.ProjectTo<Dto>(query).ToListAsync();
        }

        public async Task<Dto> CreateAsync<Dto>(Dto dto)
        {
            var entity = Mapper.Map<Entity>(dto);

            await Items.AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return Mapper.Map<Dto>(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await Items
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                DbContext.Set<Entity>().Remove(entity);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync<Dto>(Dto dto)
        {
            var entity = Mapper.Map<Entity>(dto);

            DbContext.Set<Entity>().Update(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
