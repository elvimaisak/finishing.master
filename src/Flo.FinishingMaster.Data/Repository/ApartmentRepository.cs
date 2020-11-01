using Flo.FinishingMaster.Infrastructure.Entity;
using Flo.FinishingMaster.Infrastructure.Repositories;

namespace Flo.FinishingMaster.Data.Repository
{
    public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(DataContext dataContext) : base(dataContext)
        {

        }

        protected override void CopyFields(Apartment source, Apartment target)
        {
            target.Name = source.Name;
        }
    }
}
