using Business.Dtos.User;
using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Game
{
    public class GameDtoWithIdWithNavigations
    {
        public Guid Id { get; set; }
        public Result Result { get; set; }
        public DateTime PlayedOn { get; set; }
        public UserDtoWithId User { get; set; }
    }
}
