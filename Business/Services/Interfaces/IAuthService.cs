using Business.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(UserDto userDto);

        Task<string> LoginAsync(string email, string password);
    }
}
