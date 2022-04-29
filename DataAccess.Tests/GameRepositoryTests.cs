using AutoMapper;
using Business.Dtos.Game;
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
    public class GameRepositoryTests : IDisposable
    {
        private readonly DbContextOptions<HowToChessDbContext> _dbContextOptions;
        private readonly IMapper _mapper;
        private readonly GameRepository _repository;
        private readonly HowToChessDbContext _context;

        public GameRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<HowToChessDbContext>()
                .UseInMemoryDatabase(databaseName: "HowToChessDBGameRepo")
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
            _repository = new GameRepository(_context, _mapper);
        }

        public async void Dispose()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        private async Task SeedingAsync(HowToChessDbContext context)
        {
            await Seeder.SeedRolesAsync(context);
            await Seeder.SeedUsersAsync(context);
            await Seeder.SeedGamesAsync(context);
        }

        [Theory]
        [InlineData("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc6")]
        public async Task GetByIdAsync_ValidId_UserDtoWithId(string id)
        {
            await SeedingAsync(_context);

            var guidId = Guid.Parse(id);
            var game = await _repository.GetByIdAsync<GameDtoWithIdWithNavigations>(guidId);

            Assert.Equal(game.User.Id, Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc8"));
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_NotEmptyList()
        {
            await SeedingAsync(_context);

            var results = await _repository.GetAllAsync<GameDtoWithIdWithNavigations>();

            Assert.Equal(1, results.Count);
        }

        [Fact]
        public async Task GetAllAsync_NotEnoughDataInDB_Empty()
        {
            var games = await _repository.GetAllAsync<GameDtoWithIdWithNavigations>();

            Assert.Empty(games);
        }

        [Theory]
        [InlineData("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc6")]
        public async Task UpdateAsync_ValidParameters_UpdatedUser(string id)
        {
            var guidId = Guid.Parse(id);

            await SeedingAsync(_context);

            var game = await _context.Games.SingleOrDefaultAsync(x => x.Id == guidId);
            _context.Entry(game).State = EntityState.Detached;

            var datetime = DateTime.Now;
            game.PlayedOn = datetime;

            await _repository.UpdateAsync(game);

            var count = await _context.Games.CountAsync(x => x.PlayedOn == datetime);
            Assert.Equal(1, count);
        }

        [Theory]
        [InlineData("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc6")]
        public async Task DeleteAsync_ValidId_DeletedUser(string id)
        {
            var guidId = Guid.Parse(id);

            await SeedingAsync(_context);

            var game = await _context.Games.SingleOrDefaultAsync(x => x.Id == guidId);
            _context.Entry(game).State = EntityState.Detached;

            await _repository.DeleteAsync(guidId);

            Assert.Equal(0, _context.Games.Count());
        }

        [Fact]
        public async Task CreateAsync_ValidData_CreatedCustomer()
        {
            await SeedingAsync(_context);

            var game = new GameDtoWithId()
            {
                Id = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc5"),
                PlayedOn = DateTime.Now,
                Result = Enums.Result.Win,
                UserId = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc9")
            };

            await _repository.CreateAsync(game);

            Assert.Equal(2, _context.Games.Count());
        }
    }
}
