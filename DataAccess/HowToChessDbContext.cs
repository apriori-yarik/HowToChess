﻿using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HowToChessDbContext : DbContext
    {
        public HowToChessDbContext(DbContextOptions<HowToChessDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);

                e.HasQueryFilter(x => x.IsDeleted == false);

                e.HasIndex(x => x.Email)
                .IsUnique();
            });

            modelBuilder.Entity<UserPosition>(e =>
            {
                e.HasKey(x => new { x.UserId, x.PositionId });

                e.HasOne(x => x.User)
                .WithMany(x => x.UserPositions)
                .HasForeignKey(x => x.UserId);

                e.HasOne(x => x.Position)
                .WithMany(x => x.UserPositions)
                .HasForeignKey(x => x.PositionId);
            });
        }
    }
}
