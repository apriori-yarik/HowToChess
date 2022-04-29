using AutoMapper;
using Business.Dtos.Position;
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
    public class PositionRepositoryTests : IDisposable
    {
        private readonly DbContextOptions<HowToChessDbContext> _dbContextOptions;
        private readonly IMapper _mapper;
        private readonly PositionRepository _repository;
        private readonly HowToChessDbContext _context;

        public PositionRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<HowToChessDbContext>()
                .UseInMemoryDatabase(databaseName: "HowToChessDBPositionRepo")
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
            _repository = new PositionRepository(_context, _mapper);
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
            await Seeder.SeedPositionsAsync(context);
        }

        [Theory]
        [InlineData("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc6")]
        public async Task GetByIdAsync_ValidId_PositionDtoWithId(string id)
        {
            await SeedingAsync(_context);

            var guidId = Guid.Parse(id);
            var position = await _repository.GetByIdAsync<PositionDtoWithId>(guidId);

            Assert.Equal("Position name", position.Name);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_NotEmptyList()
        {
            await SeedingAsync(_context);

            var results = await _repository.GetAllAsync<PositionDtoWithId>();

            Assert.Equal(1, results.Count);
        }

        [Fact]
        public async Task GetAllAsync_NotEnoughDataInDB_Empty()
        {
            var positions = await _repository.GetAllAsync<PositionDtoWithId>();

            Assert.Empty(positions);
        }

        [Theory]
        [InlineData("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc6", "name changed")]
        public async Task UpdateAsync_ValidParameters_UpdatedPosition(string id, string name)
        {
            var guidId = Guid.Parse(id);

            await SeedingAsync(_context);

            var position = await _context.Positions.SingleOrDefaultAsync(x => x.Id == guidId);
            _context.Entry(position).State = EntityState.Detached;

            position.Name = name;

            await _repository.UpdateAsync(position);

            var count = await _context.Positions.CountAsync(x => x.Name == "name changed");
            Assert.Equal(1, count);
        }

        [Theory]
        [InlineData("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc6")]
        public async Task DeleteAsync_ValidId_DeletedPosition(string id)
        {
            var guidId = Guid.Parse(id);

            await SeedingAsync(_context);

            var position = await _context.Positions.SingleOrDefaultAsync(x => x.Id == guidId);
            _context.Entry(position).State = EntityState.Detached;

            await _repository.DeleteAsync(guidId);

            Assert.Equal(0, _context.Positions.Count());
        }

        [Fact]
        public async Task CreateAsync_ValidData_CreatedPosition()
        {
            await SeedingAsync(_context);

            var position = new PositionDtoWithId()
            {
                Id = Guid.Parse("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc5"),
                FEN = "some fen",
                Name = "Position name",
                Description = "Description name",
                Solution = "solution",
                Likes = 10,
                Rating = 1800
            };

            await _repository.CreateAsync(position);

            Assert.Equal(2, _context.Positions.Count());
        }
    }
}
