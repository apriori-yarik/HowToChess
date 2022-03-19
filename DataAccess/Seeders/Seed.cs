using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Seeders
{
    public static class Seed
    {
        public static async Task SeedRolesAsync(HowToChessDbContext context)
        {
            if (await context.Roles.AnyAsync()) return;

            var roles = new List<Role>
            {
                new Role
                {
                    Name = "Admin",
                },
                new Role
                {
                    Name = "User",
                },
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }
    }
}
