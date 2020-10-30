using System;
using System.Threading.Tasks;
using Flo.FinishingMaster.Infrastructure.Entity;

namespace Flo.FinishingMaster.Infrastructure.Repositories
{
    public interface IRoomRepository
    {
        Task<Room> GetByIdAsync(Guid id);
        Task<Room> UpdateAsync(Room room);
        Task DeleteAsync(Guid id);
    }
}
