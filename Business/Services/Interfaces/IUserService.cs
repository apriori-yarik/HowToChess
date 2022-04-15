using Business.Dtos.User;
using Business.Dtos.UserPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDtoWithIdWithCollections> GetAsync(Guid id);

        Task<List<UserDtoWithIdWithCollections>> GetAllAsync();

        Task CreateAsync(UserDto userDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(UserDtoWithIdWithoutRole userDto);

        Task AddPositionAsync(UserDtoWithIdWithCollections userDto, UserPositionPositionIdDto userPositionDto);
    }
}
