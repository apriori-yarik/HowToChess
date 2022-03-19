using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        Task<Dto> GetByIdAsync<Dto>(Guid id);
        Task<List<Dto>> GetAllAsync<Dto>(Expression<Func<Dto, bool>> filter = null);
        Task<Dto> CreateAsync<Dto>(Dto dto);
        Task UpdateAsync<Dto>(Dto dto);
        Task DeleteAsync(Guid id);
    }
}
