using Flo.FinishingMaster.Infrastructure.Entity;
using Flo.FinishingMaster.Infrastructure.Repositories;

namespace Flo.FinishingMaster.Data.Repository
{
    public class WallRepository : Repository<Wall>, IWallRepository
    {
        public WallRepository(DataContext dataContext) : base(dataContext)
        {

        }

        protected override void CopyFields(Wall source, Wall target)
        {
            target.Height = source.Height;
            target.Width = source.Width;
            target.RoomId = source.RoomId;
        }
    }
}
