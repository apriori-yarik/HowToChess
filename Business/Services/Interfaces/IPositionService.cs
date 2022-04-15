using Business.Dtos.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IPositionService
    {
        Task<PositionDtoWithId> GetAsync(Guid id);

        Task<List<PositionDtoWithId>> GetAllAsync();

        Task CreateAsync(PositionDto positionDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(PositionDtoWithId positionDto);
    }
}
