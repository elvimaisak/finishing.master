using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flo.FinishingMaster.Data.Services;
using Flo.FinishingMaster.Infrastructure.Entity;
using Flo.FinishingMaster.Infrastructure.Repositories;
using Moq;
using Xunit;

namespace Flo.FinishingMaster.Data.Tests.Services
{
    public class RoomServiceTests
    {
        [Fact]
        public async Task UpdateAsync_WhenWallCollectionCHanges_UpdateIt()
        {
            //arrange
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var wallRepositoryMock = new Mock<IWallRepository>();

            var oldWall = new Wall { Id = Guid.NewGuid() };
            var newWall = new Wall { Id = Guid.NewGuid() };

            roomRepositoryMock.Setup(c => c.AddOrUpdateAsync(It.IsAny<Room>())).Returns(Task.FromResult(
           new Room
           {
               Walls = new List<Wall>
                    {
                        oldWall
                    }
           }
            ));

            var objectUnderTest = new RoomService(roomRepositoryMock.Object, wallRepositoryMock.Object);

            //act
            await objectUnderTest.UpdateAsync(new Room
            {
                Walls = new List<Wall> { newWall }
            });

            //assert

            wallRepositoryMock.Verify(c => c.Delete(new List<Guid> { oldWall.Id }), Times.Once);
        }
    }
}
