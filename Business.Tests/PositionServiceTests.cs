using Business.Dtos.Position;
using Business.Services;
using DataAccess.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Business.Tests
{
    public class PositionServiceTests
    {
        private readonly PositionService _service;

        public PositionServiceTests()
        {
            var repository = new Mock<IPositionRepository>();
            repository
                .Setup(x => x.GetByIdAsync<PositionDtoWithId>(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new PositionDtoWithId()));
            repository
                .Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<PositionDtoWithId, bool>>>()))
                .Returns(Task.FromResult(new List<PositionDtoWithId>()));

            _service = new PositionService(repository.Object);
        }

        [InlineData("ef6320c1-edf0-4b0c-8960-08d9f5fc3fc4")]
        [Theory]
        public async Task GetAsync_ValidId_UserModelWithId(string id)
        {
            var guidId = Guid.Parse(id);

            var user = await _service.GetAsync(guidId);

            Assert.NotNull(user);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_EmptyCollection()
        {
            var users = await _service.GetAllAsync();

            Assert.NotNull(users);
            Assert.Equal(0, users.Count);
        }
    }
}
