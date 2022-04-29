using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MinLength(3)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Rating { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }


        public ICollection<UserPosition> UserPositions { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
