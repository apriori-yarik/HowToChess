using Business.Dtos.Position;
using Business.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _repository;

        public PositionService(IPositionRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateAsync(PositionDto positionDto)
        {
            await _repository.CreateAsync(positionDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<PositionDtoWithId>> GetAllAsync()
        {
            var positions = await _repository.GetAllAsync<PositionDtoWithId>();
            return positions;
        }

        public async Task<PositionDtoWithId> GetAsync(Guid id)
        {
            var position = await _repository.GetByIdAsync<PositionDtoWithId>(id);
            return position;
        }

        public async Task UpdateAsync(PositionDtoWithId positionDto)
        {
            await _repository.UpdateAsync(positionDto);
        }


    }
}
