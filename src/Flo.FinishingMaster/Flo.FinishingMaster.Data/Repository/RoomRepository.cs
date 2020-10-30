using System;
using System.Linq;
using System.Threading.Tasks;
using Flo.FinishingMaster.Infrastructure.Entity;
using Flo.FinishingMaster.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Flo.FinishingMaster.Data.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private DataContext dataContext;

        public RoomRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = dataContext.Rooms.Where(c => c.Id == id);

            if (entity == null)
                throw new ArgumentException($"No entity with id {id} found");

            dataContext.Remove(entity);
            await dataContext.SaveChangesAsync();
        }

        public async Task<Room> GetByIdAsync(Guid id)
        {
            return await dataContext.Rooms.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Room> UpdateAsync(Room room)
        {
            var result = await GetByIdAsync(room.Id);

            if (result != null)
            {
                result.Name = room.Name;
                result.Walls = room.Walls;
            }
            else
            {
                result = (await dataContext.Rooms.AddAsync(room)).Entity;
            }

            return result;
        }
    }
}
