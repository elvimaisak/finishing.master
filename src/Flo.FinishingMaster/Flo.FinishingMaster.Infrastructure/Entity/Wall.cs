using System;

namespace Flo.FinishingMaster.Infrastructure.Entity
{
    public class Wall
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }

        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
