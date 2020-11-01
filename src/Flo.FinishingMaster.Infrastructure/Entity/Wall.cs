using System;
using System.Text.Json.Serialization;

namespace Flo.FinishingMaster.Infrastructure.Entity
{
    public class Wall : BaseEntity
    {
        public string Name { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }

        public Guid RoomId { get; set; }

        [JsonIgnore]
        public virtual Room Room { get; set; }
    }
}
