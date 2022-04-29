using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Game : BaseEntity
    {
        public Result Result { get; set; }
        public DateTime PlayedOn { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
