using System;
using System.Collections.Generic;

namespace Flo.FinishingMaster.Infrastructure.Entity
{
    public class Apartment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual List<Room> Rooms { get; set; }
    }
}
