using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Position : BaseEntity
    {
        public string FEN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public int Rating { get; set; }
        public int Likes { get; set; }

        public ICollection<UserPosition> UserPositions { get; set; }
    }
}
