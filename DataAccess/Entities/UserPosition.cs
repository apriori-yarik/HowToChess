using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class UserPosition
    {
        public Guid UserId { get; set; }
        public Guid PositionId { get; set; }
        public bool IsSolved { get; set; }

        public User User { get; set; }
        public Position Position { get; set; }
    }
}
