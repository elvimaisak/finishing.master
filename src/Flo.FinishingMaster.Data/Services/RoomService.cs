using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flo.FinishingMaster.Infrastructure.Entity;
using Flo.FinishingMaster.Infrastructure.Repositories;
using Flo.FinishingMaster.Infrastructure.Services;

namespace Flo.FinishingMaster.Data.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;
        private readonly IWallRepository wallRepository;

        public RoomService(IRoomRepository roomRepository, IWallRepository wallRepository)
        {
            this.roomRepository = roomRepository;
            this.wallRepository = wallRepository;
        }

        public void Delete(IEnumerable<Guid> ids)
        {
            roomRepository.Delete(ids);
        }

        public async Task<Room> FindByIdAsync(Guid id)
        {
            return await roomRepository.GetByIdAsync(id);
        }

        public async Task<Room> UpdateAsync(Room room)
        {
            var existingRoom = await roomRepository.AddOrUpdateAsync(room);
            await UpdateWalls(room, existingRoom);
            await roomRepository.SaveChangesAsync();

            return existingRoom;
        }

        private async Task UpdateWalls(Room editedRoom, Room existingRoom)
        {
            var wallIdsToRemove = existingRoom.Walls.Select(c => c.Id).Except(editedRoom.Walls.Select(c => c.Id));

            wallRepository.Delete(wallIdsToRemove.ToList());

            foreach (var wall in editedRoom.Walls)
            {
                wall.RoomId = editedRoom.Id;
                await wallRepository.AddOrUpdateAsync(wall);
            }
        }
    }
}
