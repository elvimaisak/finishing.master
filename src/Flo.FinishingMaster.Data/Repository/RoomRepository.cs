using Flo.FinishingMaster.Infrastructure.Entity;
using Flo.FinishingMaster.Infrastructure.Repositories;

namespace Flo.FinishingMaster.Data.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(DataContext dataContext) : base(dataContext)
        {
        }

        protected override void CopyFields(Room source, Room target)
        {
            target.ApartmentId = source.ApartmentId;
            target.Name = source.Name;
        }
    }
}
