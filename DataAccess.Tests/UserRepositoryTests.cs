using AutoMapper;
using Business.Dtos.User;
using DataAccess.Repositories;
using DataAccess.Tests.Mapper;
using DataAccess.Tests.Seeders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataAccess.Tests
{
    public class UserRepositoryTests : IDisposable
    {
         private readonly DbContextOptions<HowToChessDbContext> _dbContextOptions;
         private readonly IMapper _mapper;
         private readonly UserRepository _repository;
         private readonly HowToChessDbContext _context;

         public UserRepositoryTests()
         {
             _dbContextOptions = new DbContextOptionsBuilder<HowToChessDbContext>()
                 .UseInMemoryDatabase(databaseName: "HowToChessDBUserRepo")
                 .Options;

             if (_mapper == null)
             {
                 var mappingConfig = new MapperConfiguration(mc =>
                 {
                     mc.AddProfile(new MapperProfile());
                 });
                 IMapper mapper = mappingConfig.CreateMapper();
                 _mapper = mapper;
             }

             _context = new HowToChessDbContext(_dbContextOptions);
             _repository = new UserRepository(_context, _mapper);
         }

         public async void Dispose()
         {
             await _context.Database.EnsureDeletedAsync();
         }

         private async Task SeedingAsync(HowToChessDbContext context)
         {
             await Seeder.SeedRolesAsync(context);
             await Seeder.SeedUsersAsync(context);
         }

         [Theory]
         [InlineData("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc9")]
         public async Task GetByIdAsync_ValidId_UserDtoWithId(string id)
         {
             await SeedingAsync(_context);

             var guidId = Guid.Parse(id);
             var user = await _repository.GetByIdAsync<UserDtoWithId>(guidId);

             Assert.Equal("John Doe", user.FullName);
         }

         [Fact]
         public async Task GetAllAsync_ValidParameters_NotEmptyList()
         {
             await SeedingAsync(_context);

             var results = await _repository.GetAllAsync<UserDtoWithId>();

             Assert.Equal(3, results.Count);
         }

         [Fact]
         public async Task GetAllAsync_NotEnoughDataInDB_Empty()
         {
             var users = await _repository.GetAllAsync<UserDtoWithId>();

             Assert.Empty(users);
         }

         [Theory]
         [InlineData("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc9", "name changed")]
         public async Task UpdateAsync_ValidParameters_UpdatedUser(string id, string name)
         {
             var guidId = Guid.Parse(id);

             await SeedingAsync(_context);

             var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == guidId);
             _context.Entry(user).State = EntityState.Detached;

             user.FullName = name;

             await _repository.UpdateAsync(user);

             var count = await _context.Users.CountAsync(x => x.FullName == "name changed");
             Assert.Equal(1, count);
         }

         [Theory]
         [InlineData("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc9")]
         public async Task DeleteAsync_ValidId_DeletedUser(string id)
         {
             var guidId = Guid.Parse(id);

             await SeedingAsync(_context);

             var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == guidId);
             _context.Entry(user).State = EntityState.Detached;

             await _repository.DeleteAsync(guidId);

             Assert.Equal(2, _context.Users.Count());
         }

         [Fact]
         public async Task CreateAsync_ValidData_CreatedCustomer()
         {
             await SeedingAsync(_context);

             var user = new UserDtoWithId()
             {
                 Id = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc0"),
                 Password = "password",
                 FullName = "John Doe 3",
                 Email = "john.doe3@example.com",
                 RoleId = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fe4"),
             };

             await _repository.CreateAsync(user);

             Assert.Equal(4, _context.Users.Count());
         }
    }
}
