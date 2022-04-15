using Business.Dtos.Position;
using Business.Dtos.User;
using Business.Dtos.UserPosition;
using Business.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPositionRepository _positionRepository;

        public UserService(IUserRepository repository, IPositionRepository positionRepository)
        {
            _repository = repository;
            _positionRepository = positionRepository;
        }

        public async Task AddPositionAsync(UserDtoWithIdWithCollections userDto, UserPositionPositionIdDto userPositionDto)
        {
            var position = await _positionRepository.GetByIdAsync<PositionDtoWithId>(userPositionDto.PositionId);

            userDto.UserPositions.Add(new UserPositionPositionDto()
            {
                Position = position
            });

            await _repository.UpdateAsync(userDto);
        }

        public async Task CreateAsync(UserDto userDto)
        {
            await _repository.CreateAsync(userDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<UserDtoWithIdWithCollections>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync<UserDtoWithIdWithCollections>();
            return users;
        }

        public async Task<UserDtoWithIdWithCollections> GetAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync<UserDtoWithIdWithCollections>(id);
            return user;
        }

        public async Task UpdateAsync(UserDtoWithIdWithoutRole userDto)
        {
            userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            await _repository.UpdateAsync(userDto);
        }
    }
}
