using System;
using System.Threading.Tasks;
using Flo.FinishingMaster.Infrastructure.Entity;

namespace Flo.FinishingMaster.Infrastructure.Services
{
    public interface IRoomService
    {
        Task<Room> FindByIdAsync(Guid id);
        Task<Room> UpdateAsync(Room room);
        Task DeleteAsync(Guid id);
    }
}
