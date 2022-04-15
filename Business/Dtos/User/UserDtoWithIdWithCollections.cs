using Business.Dtos.Role;
using Business.Dtos.UserPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.User
{
    public class UserDtoWithIdWithCollections
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleDtoWithId Role { get; set; }
        public ICollection<UserPositionPositionDto> UserPositions { get; set; }
    }
}
