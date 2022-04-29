using DataAccess.Entities;
using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Tests.Seeders
{
    public static class Seeder
    {
        public static async Task SeedRolesAsync(HowToChessDbContext context)
        {
            var roles = new List<Role>
            {
                new Role
                {
                    Id = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc6"),
                    Name = "Admin",
                },
                new Role
                {
                    Id = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc5"),
                    Name = "User",
                },
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }

        public static async Task SeedUsersAsync(HowToChessDbContext context)
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc9"),
                    Password = "password",
                    FullName = "John Doe",
                    Email = "john.doe@example.com",
                    RoleId = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc6"),
                },
                new User()
                {
                    Id = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc8"),
                    Password = "password",
                    FullName = "John Doe 2",
                    Email = "john.doe2@example.com",
                    RoleId = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc6"),
                },
                new User()
                {
                    Id = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc7"),
                    Password = "password",
                    FullName = "John Doe 3",
                    Email = "john.doe3@example.com",
                    RoleId = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc5"),
                }
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }

        public static async Task SeedGamesAsync(HowToChessDbContext context)
        {
            var games = new List<Game>
            {
                new Game
                {
                    Id = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc6"),
                    Result = Result.Win,
                    PlayedOn = DateTime.Now,
                    UserId = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc8")
                },
            };

            await context.Games.AddRangeAsync(games);
            await context.SaveChangesAsync();
        }

        public static async Task SeedPositionsAsync(HowToChessDbContext context)
        {
            var positions = new List<Position>()
            {
                new Position
                {
                    Id = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc6"),
                    FEN = "some fen",
                    Name = "Position name",
                    Description = "Description name",
                    Solution = "solution",
                    Likes = 10,
                    Rating = 1800
                }
            };

            await context.Positions.AddRangeAsync(positions);
            await context.SaveChangesAsync();
        }
    }
}
