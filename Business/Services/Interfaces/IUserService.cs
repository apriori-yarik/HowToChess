using Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDtoWithId> GetAsync(Guid id);

        Task<List<UserDtoWithId>> GetAllAsync();

        Task CreateAsync(UserDto userDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(UserDtoWithId userDto);
    }
}
