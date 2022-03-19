using Business.Dtos.User;
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

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(UserDto userDto)
        {
            await _repository.CreateAsync(userDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<UserDtoWithId>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync<UserDtoWithId>();
            return users;
        }

        public async Task<UserDtoWithId> GetAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync<UserDtoWithId>(id);
            return user;
        }

        public async Task UpdateAsync(UserDtoWithIdWithoutRole userDto)
        {
            userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            await _repository.UpdateAsync(userDto);
        }
    }
}
