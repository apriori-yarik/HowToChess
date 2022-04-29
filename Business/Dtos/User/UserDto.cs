using Business.Dtos.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.User
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Rating { get; set; }
        public Guid RoleId { get; set; }
    }
}
