using System;
using System.Collections.Generic;

namespace Flo.FinishingMaster.Infrastructure.Entity
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Wall> Walls { get; set; }

    }
}
