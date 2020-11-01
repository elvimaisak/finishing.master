using System.Collections.Generic;

namespace Flo.FinishingMaster.Infrastructure.Entity
{
    public class Apartment : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Room> Rooms { get; set; } = new List<Room>();
    }
}
