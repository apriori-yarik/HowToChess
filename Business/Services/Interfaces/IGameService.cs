using Business.Dtos.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameDtoWithIdWithNavigations> GetAsync(Guid id);

        Task<List<GameDtoWithIdWithNavigations>> GetAllAsync();

        Task CreateAsync(GameDto gameDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(GameDtoWithId gameDto);
    }
}
