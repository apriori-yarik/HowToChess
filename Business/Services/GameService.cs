using Business.Dtos.Game;
using Business.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateAsync(GameDto gameDto)
        {
            await _repository.CreateAsync(gameDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<GameDtoWithIdWithNavigations>> GetAllAsync()
        {
            var games = await _repository.GetAllAsync<GameDtoWithIdWithNavigations>();
            return games;
        }

        public async Task<GameDtoWithIdWithNavigations> GetAsync(Guid id)
        {
            var game = await _repository.GetByIdAsync<GameDtoWithIdWithNavigations>(id);
            return game;
        }

        public async Task UpdateAsync(GameDtoWithId gameDto)
        {
            await _repository.UpdateAsync(gameDto);
        }

    }
}
