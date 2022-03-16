using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }
    }
}
